using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;

namespace PayrollSystem.Controllers
{
    public class AjaxController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;

        public AjaxController(UserManager<Worker> userManager, PayrollDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult LoadPositions(int? departmentId)
        {

            if (departmentId == null)
            {
                return NotFound();
            }

            var data = _context.Positions.Where(m => m.DepartmentId == departmentId);

            if (data == null)
            {
                return NotFound();
            }

            return PartialView("_LoadPositionsPartial", data);
        }

        public IActionResult LoadAbsens(int? absensId)
        {
            return NotFound();
        }

        public IActionResult LoadEmployee(int skip)
        {

            var data = _context.Employees.Select(x => new EmployeeVM
            {
                ID = x.ID,
                Birtday = x.Born,
                DistrictRegistration = x.DistrictRegistration,
                EducationText = _context.Educations.Where(m => m.EducationId == x.EducationId).Select(m => m.EducationName).FirstOrDefault(),
                FatherName = x.FatherName,
                GenderText = _context.Genders.Where(m => m.GenderId == x.GenderId).Select(m => m.GenderName).FirstOrDefault(),
                MaritalStatusText = _context.MaritalStatuses.Where(m => m.MaritalStatusId == x.MaritalStatusId).Select(m => m.MaritalStatusName).FirstOrDefault(),
                Name = x.Name,
                PersonalityCardNumber = x.PersonalityCardNumber,
                ////pe = x.IDCardFinCode,
                Residence = x.Residence,
                Surname = x.Surname,
                Image = x.Image
            }).Skip(skip).Take(2).ToList();

            return View(data);
        }

        public IActionResult LoadSalary(int skip)
        {
            var workers = _context.Users.ToList();
            string k = "";
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int currentDay = DateTime.Now.Day;

            var empId = _context.Salaries.Where(x => x.CalculatedDate.Year == year && x.CalculatedDate.Month == month).ToList();
            foreach (var item in empId)
            {
                k += ("//" + item.EmployeeId + "//");
            }

            SalaryViewModel salaryModel = new SalaryViewModel();
            salaryModel.SelectedWorkers = workers.Where(x => !k.Contains("/" + x.EmployeeId + "/")).Select(x => new SelectedWorker
            {
                Department = _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Department.Name).FirstOrDefault(),
                ID = x.Id,
                Name = _context.Employees.Where(y => y.Worker.Id == x.Id).Select(y => y.Name).FirstOrDefault(),
                IDCardNumber = _context.Employees.Where(y => y.Worker.Id == x.Id)
                          .Select(y => y.PersonalityCardNumber).FirstOrDefault(),

                Surname = _context.Employees.Where(y => y.Worker.Id == x.Id).Select(y => y.Surname).FirstOrDefault(),
                Position = _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Name).FirstOrDefault(),
                IsChecked = false,
                EmployeeId = x.EmployeeId,

                OldCalculate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),

                Bonus = _context.WorkerBonus.Where(y => y.WorkerId == x.Id && y.BonusDate.Year == year && y.BonusDate.Month == month).Sum(y => y.BonusSalary)
                       + _context.CompanyWorkPlaceBonus.Include(m => m.CompanyWorkPlace)
                          .Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == year && y.CompanyWorkPlace.ChangedDate.Month == month).Select(y => y.BonusSalary).FirstOrDefault(),

                MonthlySalary = _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Salary).FirstOrDefault() / daysInMonth * currentDay,

                ExcusableAbsens = _context.WorkerAbsens.Where(y => y.AbsenceId == 1 && y.WorkerId == x.Id && y.Date.Year == year && y.Date.Month == month).Count()
                          + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == year && y.CompanyWorkPlace.ChangedDate.Month == month)
                              .Select(y => y.ExcusableAbsens).FirstOrDefault(),

                UnExcusableAbsens = _context.WorkerAbsens.Where(y => y.AbsenceId == 2 && y.WorkerId == x.Id && y.Date.Year == year && y.Date.Month == month).Count()
                          + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == year && y.CompanyWorkPlace.ChangedDate.Month == month)
                              .Select(y => y.UnExcusableAbsens).FirstOrDefault(),

                AbsensCount = _context.WorkerAbsens.Where(y => y.AbsenceId == 1 && y.WorkerId == x.Id).Count()
                          + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId)
                              .Select(y => y.ExcusableAbsens).FirstOrDefault()
                                  + _context.WorkerAbsens.Where(y => y.AbsenceId == 2 && y.WorkerId == x.Id).Count()
                                       + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId)
                                          .Select(y => y.UnExcusableAbsens).FirstOrDefault(),

                TotalSalary = (_context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Salary).FirstOrDefault() / daysInMonth * currentDay - _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Salary).FirstOrDefault() / daysInMonth
                               * _context.WorkerAbsens.Where(y => y.AbsenceId == 2 && y.WorkerId == x.Id && y.Date.Year == year && y.Date.Month == month).Count()
                                  + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == year && y.CompanyWorkPlace.ChangedDate.Month == month)
                                      .Select(y => y.UnExcusableAbsens).FirstOrDefault())
                                          + _context.WorkerBonus.Where(y => y.WorkerId == x.Id && y.BonusDate.Year == year && y.BonusDate.Month == month).Sum(y => y.BonusSalary)
                       + _context.CompanyWorkPlaceBonus.Include(m => m.CompanyWorkPlace)
                          .Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == year && y.CompanyWorkPlace.ChangedDate.Month == month).Select(y => y.BonusSalary).FirstOrDefault()

            }).Skip(skip).Take(2).ToList();

            return View(salaryModel);
        }


        public IActionResult LoadShopBonus(string selectedDate, int skip)
        {
            DateTime date = Convert.ToDateTime(selectedDate);
            SaleVM saleViewModel = new SaleVM();

            saleViewModel.AvialableShops = _context.Shops.Select(y => new AvialableShop
            {
                SaleSalary = _context.Sales.Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.ShopId == y.ID).Sum(x => x.SaleSalary),
                ShopName = y.Name,
                SelectedDate = date,
                ShopId = y.ID
            }).Skip(skip).Take(2).ToList();

            return View(saleViewModel);
        }

        public async Task<IActionResult> LoadBonusWorkerList(int skip)
        {

            var user = await _context.Users.Include(x => x.Position).SingleOrDefaultAsync(x => _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult().Id == x.Id);
            var id = user.Position.DepartmentId;
            var data = await (from work in _userManager.Users
                              join emp in _context.Employees
                              on work.EmployeeId equals emp.ID
                              join pos in _context.Positions
                              on work.PositionId equals pos.ID
                              join dep in _context.Departments
                              on pos.DepartmentId equals dep.ID
                              where dep.ID == id
                              select new WorkerVM
                              {
                                  WorkerId = work.Id,
                                  Email = work.Email,
                                  Name = emp.Name,
                                  Surname = emp.Surname,
                                  Position = pos.Name,
                                  Department = dep.Name,
                                  StartDate = work.BeginDate
                              }).Skip(skip).Take(2).ToListAsync();

            return View(data);
        }

        public async Task<IActionResult> LoadDepartmentList(int skip)
        {

            var departments = await _context.Departments.Select(x => new DepartmentVM
            {
                ID = x.ID,
                Name = x.Name,
                Company = x.Company

            }).Skip(skip).Take(2).ToListAsync();

            return View(departments);
        }


        public IActionResult LoadCalculateSalary(string selectedDate, int skip)
        {
            if (selectedDate == null)
            {
                return NotFound();
            }
            var date = Convert.ToDateTime(selectedDate);
            var workers = _context.Users.ToList();
            string k = "";
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var empId = _context.Salaries.Where(x => x.CalculatedDate.Year == date.Year && x.CalculatedDate.Month == date.Month).ToList();

            foreach (var item in empId)
            {
                k += ("//" + item.EmployeeId + "//");
            }

            SalaryViewModel salaryModel = new SalaryViewModel();

            salaryModel.SelectedWorkers = workers.Where(x => !k.Contains("/" + x.EmployeeId + "/")).Select(x => new SelectedWorker
            {
                Department = _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Department.Name).FirstOrDefault(),
                ID = x.Id,
                Name = _context.Employees.Where(y => y.Worker.Id == x.Id).Select(y => y.Name).FirstOrDefault(),
                IDCardNumber = _context.Employees.Where(y => y.Worker.Id == x.Id)
                          .Select(y => y.PersonalityCardNumber).FirstOrDefault(),

                Surname = _context.Employees.Where(y => y.Worker.Id == x.Id).Select(y => y.Surname).FirstOrDefault(),
                Position = _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Name).FirstOrDefault(),
                IsChecked = false,
                EmployeeId = x.EmployeeId,

                OldCalculate = date,

                Bonus = _context.WorkerBonus.Where(y => y.WorkerId == x.Id && y.BonusDate.Year == date.Year && y.BonusDate.Month == date.Month).Sum(y => y.BonusSalary)
                       + _context.CompanyWorkPlaceBonus.Include(m => m.CompanyWorkPlace)
                          .Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == date.Year && y.CompanyWorkPlace.ChangedDate.Month == date.Month).Select(y => y.BonusSalary).FirstOrDefault(),

                MonthlySalary = _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Salary).FirstOrDefault(),

                ExcusableAbsens = _context.WorkerAbsens.Where(y => y.AbsenceId == 1 && y.WorkerId == x.Id && y.Date.Year == date.Year && y.Date.Month == date.Month).Count()
                          + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == date.Year && y.CompanyWorkPlace.ChangedDate.Month == date.Month)
                              .Select(y => y.ExcusableAbsens).FirstOrDefault(),

                UnExcusableAbsens = _context.WorkerAbsens.Where(y => y.AbsenceId == 2 && y.WorkerId == x.Id && y.Date.Year == date.Year && y.Date.Month == date.Month).Count()
                          + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == date.Year && y.CompanyWorkPlace.ChangedDate.Month == date.Month)
                              .Select(y => y.UnExcusableAbsens).FirstOrDefault(),

                AbsensCount = _context.WorkerAbsens.Where(y => y.AbsenceId == 1 && y.WorkerId == x.Id).Count()
                          + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId)
                              .Select(y => y.ExcusableAbsens).FirstOrDefault()
                                  + _context.WorkerAbsens.Where(y => y.AbsenceId == 2 && y.WorkerId == x.Id).Count()
                                       + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId)
                                          .Select(y => y.UnExcusableAbsens).FirstOrDefault(),

                TotalSalary = (_context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Salary).FirstOrDefault() - _context.Positions.Where(y => y.ID == x.PositionId).Select(y => y.Salary).FirstOrDefault() / daysInMonth
                               * _context.WorkerAbsens.Where(y => y.AbsenceId == 2 && y.WorkerId == x.Id && y.Date.Year == date.Year && y.Date.Month == date.Month).Count()
                                  + _context.CompanyWorkPlaceAbsences.Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == date.Year && y.CompanyWorkPlace.ChangedDate.Month == date.Month)
                                      .Select(y => y.UnExcusableAbsens).FirstOrDefault())
                                          + _context.WorkerBonus.Where(y => y.WorkerId == x.Id && y.BonusDate.Year == date.Year && y.BonusDate.Month == date.Month).Sum(y => y.BonusSalary)
                       + _context.CompanyWorkPlaceBonus.Include(m => m.CompanyWorkPlace)
                          .Where(y => y.CompanyWorkPlace.EmployeeId == x.EmployeeId && y.CompanyWorkPlace.ChangedDate.Year == date.Year && y.CompanyWorkPlace.ChangedDate.Month == date.Month).Select(y => y.BonusSalary).FirstOrDefault()

            }).Skip(skip).Take(2).ToList();

            return View(salaryModel);
        }


        public async Task<IActionResult> LoadWorkers(int skip)
        {
            var data = await (from work in _userManager.Users
                              join emp in _context.Employees
                              on work.EmployeeId equals emp.ID
                              join pos in _context.Positions
                              on work.PositionId equals pos.ID
                              join dep in _context.Departments
                              on pos.DepartmentId equals dep.ID
                              select new WorkerVM
                              {
                                  WorkerId = work.Id,
                                  Email = work.Email,
                                  Name = emp.Name,
                                  Surname = emp.Surname,
                                  Position = pos.Name,
                                  Department = dep.Name,
                                  StartDate = work.BeginDate
                              }).Skip(skip).Take(2).ToListAsync();

            return View(data);
        }
    }

}