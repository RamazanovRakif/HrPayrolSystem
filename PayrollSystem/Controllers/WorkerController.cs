using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;
using static PayrollSystem.Models.SD;

namespace PayrollSystem.Controllers
{
   [Authorize]
    public class WorkerController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _env;
        public WorkerController(IHostingEnvironment env, PayrollDbContext context, UserManager<Worker> userManager, RoleManager<IdentityRole> roleManagerr)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
            _roleManager = roleManagerr;
        }


        public IActionResult Create()
        {
            WorkerVM workerModel = new WorkerVM
            {
                Shops = _context.Shops.ToList(),
                Departments = _context.Departments.ToList(),
                Employees = _context.Employees.Where(x => x.Worker == null).ToList(),
            };
            return View(workerModel);
        }


        [Authorize(Roles = SD.HR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkerVM workerVM)
        {
            if (!ModelState.IsValid)
            {
                workerVM.Shops = _context.Shops.ToList();
                workerVM.Employees = _context.Employees.Where(x => x.Worker == null).ToList();
                workerVM.Departments = _context.Departments.ToList();
                return View(workerVM);
            }
            Worker worker = new Worker();

            if (workerVM.SelectedShop == 0)
            {
                worker.ShopId = null;
            }

            worker.ShopId = workerVM.SelectedShop;
            workerVM.Password = $"{Path.GetRandomFileName().ToUpper()}_{Path.GetRandomFileName().ToLower()}_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}";

            worker.Email = workerVM.Email;
            worker.EmployeeId = workerVM.SelectedEmployee;
            worker.PositionId = workerVM.SelectedPosition;
            worker.UserName = workerVM.Email;
            worker.Account = _context.Employees.Where(x => x.ID == workerVM.SelectedEmployee).Select(x => x.Name).FirstOrDefault() + " "
                                          + _context.Employees.Where(x => x.ID == workerVM.SelectedEmployee).Select(x => x.Surname).FirstOrDefault();
            worker.PassText = workerVM.Password;
            worker.BeginDate = workerVM.StartDate;
            worker.Worked =true;


            IdentityResult result = await _userManager.CreateAsync(worker, workerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                workerVM.Employees = _context.Employees.ToList();
                workerVM.Departments = _context.Departments.ToList();
                return View(workerVM);
            }
            await _userManager.AddToRoleAsync(worker, Roles.Worker.ToString());

            return RedirectToAction(nameof(List));
        }

        [Authorize(Roles = "HR,Admin")]
        public async Task<IActionResult>List()
        {
            var workers = await _context.Users.Include(x => x.Employee).Include(x => x.Position).Include(x => x.Position.Department).Where(x => x.Worked == true).Select(x => new WorkerVM
            {
                WorkerId = x.Id,
                Email = x.Email,
                Name = x.Employee.Name,
                Surname = x.Employee.Surname,
                Position = x.Position.Name,
                Department = x.Position.Department.Name,
                StartDate = x.BeginDate
            }).ToListAsync();

            return View(workers);

           
        }

        [Authorize(Roles = SD.HR)]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var worker = await _userManager.FindByIdAsync(id);
            WorkerVM workersView = new WorkerVM
            {
                Departments = _context.Departments.ToList(),
                Employees = _context.Employees.ToList(),
                Name = _context.Employees.Where(x => x.ID == worker.EmployeeId).Select(x => x.Name).FirstOrDefault(),
                Surname = _context.Employees.Where(x => x.ID == worker.EmployeeId).Select(x => x.Surname).FirstOrDefault(),
                Position = _context.Positions.Where(x => x.ID == worker.PositionId).Select(x => x.Name).FirstOrDefault(),
                Email = worker.Email,
                Department = _context.Positions.Include(m => m.Department).Where(x => x.ID == worker.PositionId).Select(m => m.Department.Name).FirstOrDefault()
            };

            return View(workersView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, WorkerVM workersView)
        {
            var workers = await _userManager.FindByIdAsync(id);


            string companyWorkPlaceId = $"{Path.GetRandomFileName()}_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}";
            string companyWorkPlaceBonusId = $"{Path.GetRandomFileName().ToLower()}_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}";
            string companyWorkPlaceAbsensId = $"{Path.GetRandomFileName().ToUpper()}_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}";

            workersView.Departments = _context.Departments.ToList();
            workersView.Employees = _context.Employees.ToList();
            workersView.Name = _context.Employees.Where(x => x.ID == workers.EmployeeId).Select(x => x.Name).FirstOrDefault();
            workersView.Surname = _context.Employees.Where(x => x.ID == workers.EmployeeId).Select(x => x.Surname).FirstOrDefault();
            workersView.Position = _context.Positions.Where(x => x.ID == workers.PositionId).Select(x => x.Name).FirstOrDefault();
            workersView.Email = workers.Email;
            workersView.Department = _context.Positions.Include(m => m.Department).Where(x => x.ID == workers.PositionId).Select(m => m.Department.Name).FirstOrDefault();
            workersView.Password = workers.PassText;

            if (!ModelState.IsValid)
            {
                return View(workersView);
            }

            if (workersView.SelectedPosition == workers.PositionId)
            {
                return View(workersView);
            }

            CompanyWorkPlace companyWorkPlace = new CompanyWorkPlace
            {
                ID = companyWorkPlaceId,
                EmployeeId = workers.EmployeeId,
                ChangedDate = DateTime.Now,
                PositionId = workersView.SelectedPosition
            };

            _context.CompanyWorkPlaces.Add(companyWorkPlace);

            CompanyWorkPlaceBonus companyWorkPlaceBonus = new CompanyWorkPlaceBonus
            {
                ID = companyWorkPlaceBonusId,
                CompanyWorkPlaceId = companyWorkPlaceId,
                BonusSalary = _context.WorkerBonus.Where(x => x.WorkerId == workers.Id).Select(x => x.BonusSalary).Sum()
            };
            _context.CompanyWorkPlaceBonus.Add(companyWorkPlaceBonus);

            CompanyWorkPlaceAbsence cwpa = new CompanyWorkPlaceAbsence
            {
                ID = companyWorkPlaceAbsensId,
                CompanyWorkPlaceId = companyWorkPlaceId,
                ExcusableAbsens = _context.WorkerAbsens.Where(x => x.WorkerId == workers.Id && x.AbsenceId == 1).Count(),
                UnExcusableAbsens = _context.WorkerAbsens.Where(x => x.WorkerId == workers.Id && x.AbsenceId == 2).Count()
            };
            _context.CompanyWorkPlaceAbsences.Add(cwpa);

            Worker worker = new Worker
            {
                BeginDate = DateTime.Now,
                Account = workers.Account,
                Email = workers.Email,
                EmployeeId = workers.EmployeeId,
                PassText = workers.PassText,
                UserName = workers.UserName,
                PositionId = workersView.SelectedPosition
            };

            _context.WorkerBonus.RemoveRange(_context.WorkerBonus.Where(x => x.WorkerId == workers.Id).ToList());
            _context.WorkerAbsens.RemoveRange(_context.WorkerAbsens.Where(x => x.WorkerId == workers.Id).ToList());

            await _userManager.DeleteAsync(workers);

            IdentityResult result = await _userManager.CreateAsync(worker, workers.PassText);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            await _userManager.AddToRoleAsync(worker, Roles.Worker.ToString());
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }

        [Authorize(SD.HR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var worker = await _userManager.FindByIdAsync(id);
            if (worker != null)
            {
                await _userManager.DeleteAsync(worker);
                return RedirectToAction(nameof(List));
            }

            return BadRequest();
        }

        [Authorize(Roles = SD.HR)]
        public async Task<IActionResult> RemoveWork()
        {
            var workers = await _context.Users.Include(x => x.Employee).Include(x => x.Position).Include(x => x.Position.Department).Where(x => x.Worked == false).Select(x => new WorkerVM
            {
                WorkerId = x.Id,
                Email = x.Email,
                Name = x.Employee.Name,
                Surname = x.Employee.Surname,
                Position = x.Position.Name,
                Department = x.Position.Department.Name,
               StartDate = x.BeginDate
            }).ToListAsync();

            if (workers == null)
            {
                return NoContent();
            }

            return View(workers);
        }

        [Authorize(Roles = SD.HR)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult UndoWorker(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var worker = _context.Users.Find(id);

            if (worker != null)
            {
                worker.Worked = true;
                _context.SaveChanges();
                return RedirectToAction(nameof(RemoveWork));
            }
            return BadRequest();
        }

        [Authorize(Roles = SD.Admin)]
        public async Task<IActionResult> ChangeRole(string id)
        {
            var user = await _context.Users.Where(x => x.Id == id).Include(x => x.Employee).Include(x => x.Position).Include(x => x.Position.Department).FirstOrDefaultAsync();
            var role = await _context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).FirstOrDefaultAsync();

            var roleVM = new RoleVM
            {
                Roles = _roleManager.Roles.ToList(),
                Name = user.Employee.Name,
                Surname = user.Employee.Surname,
                WorkerId = user.Id,
                Position = user.Position.Name,
                Department = user.Position.Department.Name,
                RoleName = _roleManager.Roles.Where(x => x.Id == role).Select(x => x.Name).FirstOrDefault()
            };
            return View(roleVM);
        }

        [Authorize(Roles = SD.Admin)]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(RoleVM roleVM)
        {
            var worker = await _userManager.FindByIdAsync(roleVM.WorkerId);

            await _userManager.RemoveFromRolesAsync(worker, await _userManager.GetRolesAsync(worker));

            await _userManager.AddToRoleAsync(worker, (await _roleManager.FindByIdAsync(roleVM.SelectedRole)).Name);

            return RedirectToAction(nameof(List));
        }
    }
}