using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;

namespace PayrollSystem.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class PositionController : Controller
    {
        private readonly PayrollDbContext _context;
        public PositionController(PayrollDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            PositionVM position = new PositionVM();
            position.Departments = _context.Departments.ToList();
            return View(position);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(PositionVM positionVM)
        {

            if (!ModelState.IsValid || positionVM.SelectedDepartment == 0)
            {
                positionVM.Departments = _context.Departments.ToList();
                return View(positionVM);
            }
            Position position = new Position();

            position.DepartmentId = positionVM.SelectedDepartment;
            position.Name = positionVM.Name;
            position.Salary = positionVM.Salary;
            _context.Positions.Add(position);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var positions = await _context.Positions.Select(x => new PositionVM
            {
                ID = x.ID,
                Name = x.Name,
                Department = x.Department,
                Salary = x.Salary

            }).ToListAsync();

            return View(positions);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var position = _context.Positions.Find(id);

            PositionVM positionVM = new PositionVM();
            positionVM.Name = position.Name;
            positionVM.Departments = _context.Departments.ToList();
            positionVM.DepartmentName = position.Department.Name;
            positionVM.Salary = position.Salary;
            positionVM.ID = id;

            return View(positionVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PositionVM pVM)
        {
            var position = _context.Positions.Find(id);

            if (!ModelState.IsValid)
            {
                pVM.Departments = _context.Departments.ToList();
                pVM.DepartmentName = position.Department.Name;
                pVM.Salary = position.Salary;
                return View(pVM);
            }

            position.Name = pVM.Name;
            position.DepartmentId = pVM.SelectedDepartment;
            position.Salary = pVM.Salary;
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = _context.Positions.Find(id);

            _context.Positions.Remove(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
    }
}