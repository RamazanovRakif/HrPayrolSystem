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
    [Authorize(Roles = SD.HR)]
    public class PenaltyController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;

        public PenaltyController(PayrollDbContext context, UserManager<Worker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            if (id == null) return NotFound();
           
            var workers = await _userManager.FindByIdAsync(id);

            AbsenceVM addAbsens = new AbsenceVM
            {
                WorkerAccount = workers.Account,
                WorkerId = workers.Id,
                Absence = _context.Absences.ToList()
            };

            return View(addAbsens);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id,AbsenceVM absenceVM)
        {
            var workers = await _userManager.FindByIdAsync(id);

            if (!ModelState.IsValid)
            {
                absenceVM.WorkerAccount = workers.Account;
                absenceVM.WorkerId = workers.Id;
                absenceVM.Absence = _context.Absences.ToList();
                return View(absenceVM);
            }

            WorkerAbsens absenceForWorker = new WorkerAbsens
            {
                WorkerId = workers.Id,
                AbsenceId = absenceVM.SelectedAbsence,
                Date = DateTime.Now,
                Reason = absenceVM.Reason
            };

            await _context.WorkerAbsens.AddAsync(absenceForWorker);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Worker");
        }
    }
}