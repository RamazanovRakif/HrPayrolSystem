using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;

namespace PayrollSystem.Controllers
{
    [Authorize(SD.HR)]
    public class VacationController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;
        public VacationController(PayrollDbContext context, UserManager<Worker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var worker = await _userManager.FindByIdAsync(id);

            VacationVM v = new VacationVM();
            v.WorkerId = worker.Id;
            v.WorkerAccount = worker.Account;
            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, VacationVM vacationVM)
        {
            var worker = await _userManager.FindByIdAsync(id);

            if (!ModelState.IsValid)
            {
                vacationVM.WorkerAccount = worker.Account;
                vacationVM.WorkerId = worker.Id;
                return View(vacationVM);
            }

            Vacation vacation = new Vacation();

            vacation.WorkerId = worker.Id;
            vacation.StartDate = vacationVM.StartDate;
            vacation.EndDate = vacationVM.EndDate;

            await _context.Vacations.AddAsync(vacation);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Worker");
        }
    }
}