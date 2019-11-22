using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;

namespace PayrollSystem.Controllers
{
    [Authorize(Roles = SD.PayrollSpecalist)]
    public class SalaryController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;

        public SalaryController(PayrollDbContext context, UserManager<Worker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        

        public async Task<IActionResult> SalaryForWorker()
        {
            ViewBag.SkipCount = 5;
            var workers = await _context.Users.Where(x => x.Worked == true).ToListAsync();
            ViewBag.TotalCount = workers.Count();

            string k = "";
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int currentDay = DateTime.Now.Day;

            var empId = await _context.Salaries.Where(x => x.CalculatedDate.Year == year && x.CalculatedDate.Month == month).ToListAsync();
            foreach (var item in empId)
            {
                k += ("//" + item.EmployeeId + "//");
            }

            SalaryViewModel salaryModel = new SalaryViewModel();
            salaryModel.SelectedWorkers = workers.Where(x => !k.Contains("/" + x.EmployeeId + "/") && x.Worked==true).Select(x => new SelectedWorker
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
                           + x.Position.Salary / daysInMonth * (_context.Vacations.Where(v => v.WorkerId == x.Id && v.EndDate.Year == year && v.EndDate.Month == month).Select(v => (v.EndDate.Day - v.StartDate.Day)).Count()) * 2
            }).Take(5).ToList();

            return View(salaryModel);
        }


        [HttpGet]
        public IActionResult Calculate(string selectedDate)
        {
            ViewBag.SkipCount = 5;
            if (selectedDate == null)
            {
                return NotFound();
            }
            var date = Convert.ToDateTime(selectedDate);
            var workers = _context.Users.Where(x => x.Worked == true).ToList();

            string k = "";
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var empId = _context.Salaries.Where(x => x.CalculatedDate.Year == date.Year && x.CalculatedDate.Month == date.Month).ToList();

            foreach (var item in empId)
            {
                k += ("//" + item.EmployeeId + "//");
            }

            SalaryViewModel salary = new SalaryViewModel();

            salary.SelectedWorkers = workers.Where(x => !k.Contains("/" + x.EmployeeId + "/") && x.Worked==true).Select(x => new SelectedWorker
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
                           + (x.Position.Salary / daysInMonth * (_context.Vacations.Where(v => v.WorkerId == x.Id && v.EndDate.Year == date.Year && v.EndDate.Month == date.Month).Select(v => (v.EndDate.Day - v.StartDate.Day)).Count())) * 2
            }).Take(5).ToList();
            ViewBag.TotalCount = salary.SelectedWorkers.Count();
            return View(salary);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Calculate(SalaryViewModel salaryVM)
        {
            List<Salary> salary = new List<Salary>();
            
            foreach (var item in salaryVM.SelectedWorkers)
            {
                if (item.IsChecked == true)
                {
                    salary.Add(new Salary() { EmployeeId = item.EmployeeId, TotalSalary = item.TotalSalary, CalculatedDate = item.OldCalculate });
                }
            }

            
            _context.Salaries.AddRange(salary);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(SalaryForWorker));
        }
    }
}