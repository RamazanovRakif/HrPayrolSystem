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
    [Authorize(SD.Admin)]
    public class DepartmentController : Controller
    {
        private readonly PayrollDbContext _context;
        public DepartmentController(PayrollDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            DepartmentVM department = new DepartmentVM();
            department.Companies = _context.Companies.ToList();
            return View(department);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentVM departmentVM)
        {

            if (!ModelState.IsValid || departmentVM.SelectedCompany == 0)
            {
                departmentVM.Companies = _context.Companies.ToList();
                return View(departmentVM);
            }
            Department department = new Department();

            department.CompanyId = departmentVM.SelectedCompany;
            department.Name = departmentVM.Name;
            _context.Departments.Add(department);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            var departments = await _context.Departments.Select(x => new DepartmentVM
            {
                ID = x.ID,
                Name = x.Name,
                Company = x.Company

            }).ToListAsync();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _context.Departments.Find(id);

            DepartmentVM d = new DepartmentVM();
            d.Name = data.Name;
            d.Companies = _context.Companies.ToList();
            d.CompanyName = data.Company.Name;
            d.ID = id;

            return View(d);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DepartmentVM departmentVM)
        {
            var department = _context.Departments.Find(id);

            if (!ModelState.IsValid)
            {
                departmentVM.Companies = _context.Companies.ToList();
                departmentVM.CompanyName = department.Company.Name;
                return View(departmentVM);
            }

            department.Name = departmentVM.Name;
            department.CompanyId = departmentVM.SelectedCompany;
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
               var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));       
        }
    }
}