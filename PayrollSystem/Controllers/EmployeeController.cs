using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Extensions;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;
using static PayrollSystem.Utilities.Utilities;

namespace PayrollSystem.Controllers
{
    [Authorize(Roles = SD.HR)]
    public class EmployeeController : Controller
    {
        private readonly UserManager<Worker> _userManager;
        private readonly PayrollDbContext _context;
        private readonly IHostingEnvironment _env;
        public EmployeeController(PayrollDbContext context, IHostingEnvironment env, UserManager<Worker> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> Create()
        {
            var Employee = new EmployeeVM
            {
                Genders =  await _context.Genders.ToListAsync(),
                Educations = await _context.Educations.ToListAsync(),
                Maritals = await _context.MaritalStatuses.ToListAsync()
            };

            return View(Employee);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeVM create, Employee employee)
        {
            create.Genders = _context.Genders.ToList();
            create.Maritals = _context.MaritalStatuses.ToList();
            create.Educations = _context.Educations.ToList();

            string imgName = $"{Path.GetRandomFileName().ToUpper()}_{Path.GetRandomFileName().ToLower()}_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}.jpeg";

            if (!ModelState.IsValid)
            {
                return View(create);
            }

            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View(create);
            }

            if (!create.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "File type must be image");
                return View(create);
            }

            employee.Image = await employee.Photo.SaveAsync(_env.WebRootPath,"emp");

            employee.Name = create.Name;
            employee.Surname = create.Surname;
            employee.FatherName = create.FatherName;
            employee.Born = create.Birtday;
            employee.Residence = create.Residence;
            employee.PersonalityCardNumber = create.PersonalityCardNumber;
            employee.PersonalityCardEndDate = create.PersonalityCardEndDate;
            employee.DistrictRegistration = create.DistrictRegistration;
            employee.EducationId = create.SelectedEducation;
            employee.GenderId = create.SelectedGender;
            employee.MaritalStatusId = create.SelectedMarital;



            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public async Task<IActionResult> AddWorkPlace(int id)
        {
            var employe = await _context.Employees.FindAsync(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorkPlace(Employee employee)
        {

            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewBag.TotalCount = _context.Employees.Count();
            ViewBag.SkipCount = 4;
            var data = _context.Employees.Include(x=>x.Education).Select(x => new EmployeeVM
            {
                ID = x.ID,
                FatherName = x.FatherName,
                Name = x.Name,
                EducationText=x.Education.EducationName,
                Surname = x.Surname,
                Image = x.Image
            }).Take(4).ToList();

            return View(data);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var e = await _context.Employees.FindAsync(id);

            EmployeeVM employee = new EmployeeVM
            {
                Name = e.Name,
                Surname = e.Surname,
                FatherName = e.FatherName,
                Birtday = e.Born,
                DistrictRegistration = e.DistrictRegistration,
                GenderText = _context.Genders.Where(k => k.GenderId == e.GenderId).Select(k => k.GenderName).FirstOrDefault(),
                EducationText = _context.Educations.Where(k => k.EducationId == e.EducationId).Select(k => k.EducationName).FirstOrDefault(),
                MaritalStatusText = _context.MaritalStatuses.Where(k => k.MaritalStatusId == e.MaritalStatusId).Select(k => k.MaritalStatusName).FirstOrDefault(),
                PersonalityCardEndDate = e.PersonalityCardEndDate,
                PersonalityCardNumber = e.PersonalityCardNumber,
                Residence = e.Residence,
                Educations = _context.Educations.ToList(),
                Genders = _context.Genders.ToList(),
                Maritals = _context.MaritalStatuses.ToList(),
                Image = e.Image
            };

            if (employee == null)
            {
                return BadRequest();
            }

            return View(employee);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeVM employee)
        {
            employee.Genders = _context.Genders.ToList();
            employee.Maritals = _context.MaritalStatuses.ToList();
            employee.Educations = _context.Educations.ToList();
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            var employeedb = await _context.Employees.FindAsync(id);

            if (employee.Photo !=null)
            {
                
                if (!employee.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "File type must be image");

                }

         
                RemoveImage(_env.WebRootPath, employeedb.Image);

                employeedb.Image = await employee.Photo.SaveAsync(_env.WebRootPath, "employee");

               
            }
            
            employeedb.Name = employee.Name;
            employeedb.Surname = employee.Surname;
            employeedb.FatherName = employee.FatherName;
            employeedb.Residence = employee.Residence;
            employeedb.DistrictRegistration = employee.DistrictRegistration;
            employeedb.PersonalityCardEndDate = employee.PersonalityCardEndDate;
            employeedb.PersonalityCardNumber = employee.PersonalityCardNumber;
            employee.OldWorkPlaces = employee.OldWorkPlaces;
            employeedb.EducationId = employee.SelectedEducation;
            employeedb.GenderId = employee.SelectedGender;
            employeedb.MaritalStatusId = employee.SelectedMarital;
            employeedb.Born = employee.Birtday;

            //await _context.Employees.AddAsync(employeedb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));

        }

        #region EmployeeDetails
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var data = await _context.Employees.FindAsync(id);

            if (data == null) return BadRequest();

            return View(data);
        }
        #endregion




        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {


            var data = await _context.Employees.FindAsync(id);

            if (data != null)
            {
                _context.Employees.Remove(data);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(List));
            }
            return BadRequest();
        }

        public async Task<IActionResult> Detailss(int? id)
        {
            if (id == null) return NotFound();
            var data = await _context.Employees.ToListAsync();
            if (data == null) return NotFound();
            return View(data);

        }
    }
}