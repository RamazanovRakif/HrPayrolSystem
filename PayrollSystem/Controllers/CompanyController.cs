using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Extensions;
using PayrollSystem.Models;

namespace PayrollSystem.Controllers
{
    [Authorize(SD.Admin)]
    public class CompanyController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly IHostingEnvironment _env;
        public CompanyController(PayrollDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;

        }
        public async Task<IActionResult> List()
        {
            var companies = await _context.Companies.ToListAsync();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company )
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var data = await _context.Companies.FindAsync(id);
            if (data == null) return NotFound();
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int ? id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }          
            var data = await _context.Companies.FindAsync(id);
            data.Name = company.Name;
            data.Email = company.Email;
            data.Addres = company.Addres;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            
            var company =  _context.Companies.Find(id);
           _context.Companies.Remove(company);
          await  _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

    }
}