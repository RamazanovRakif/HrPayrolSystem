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
    [Authorize]
    public class BonusController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;

        public BonusController(UserManager<Worker> userManager, PayrollDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "DepartmentHead")]
        public async Task<IActionResult> List()
        {
            ViewBag.SkipCount = 6;
            var user = await _context.Users.Include(x => x.Position).SingleOrDefaultAsync(x => _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult().Id == x.Id);
            var id = user.Position.DepartmentId;
            var workers = await _context.Users.ToListAsync();
            ViewBag.TotalCount = workers.Count();

            var data = await (from work in _userManager.Users
                              join emp in _context.Employees
                              on work.EmployeeId equals emp.ID
                              join pos in _context.Positions
                              on work.PositionId equals pos.ID
                              join dep in _context.Departments
                              on pos.DepartmentId equals dep.ID
                              where dep.ID == id && work.Worked == true
                              select new WorkerVM
                              {
                                  WorkerId = work.Id,
                                  Email = work.Email,
                                  Name = emp.Name,
                                  Surname = emp.Surname,
                                  Position = pos.Name,
                                  Department = dep.Name,
                                  StartDate = work.BeginDate
                              }).Take(6).ToListAsync();

            return View(data);
        }

        [Authorize(Roles = SD.DepartmentHead)]
        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            if (id == null) return NotFound();

            var workers = await _userManager.FindByIdAsync(id);
            BonusVM bonus = new BonusVM
            {
                WorkerAccount = workers.Account,
                WorkerID = workers.Id
            };
            return View(bonus);
        }

        [Authorize(Roles = SD.DepartmentHead)]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, BonusVM bonusvm)
        {
            var workers = await _userManager.FindByIdAsync(id);
            if (!ModelState.IsValid)
            {
                bonusvm.WorkerID = workers.Id;
                bonusvm.WorkerAccount = workers.Account;
                return View(bonusvm);
            }

            WorkerBonus bonus = new WorkerBonus
            {
                WorkerId = workers.Id,
                BonusSalary = bonusvm.BonusSalary,
                BonusDate = DateTime.Now,
                Reason = bonusvm.Reason
            };

            _context.WorkerBonus.Add(bonus);

            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [Authorize(Roles = SD.PayrollSpecalist)]
        public IActionResult ShopBonus(string selectedDate)
        {
            DateTime date = Convert.ToDateTime(selectedDate);
            SaleVM sale = new SaleVM();

            sale.AvialableShops = _context.Shops.Select(y => new AvialableShop
            {
                ShopId = y.ID,
                SaleSalary = _context.Sales.Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.ShopId == y.ID).Sum(x => x.SaleSalary),
                ShopName = y.Name,
                SelectedDate = date,
               
            }).ToList();

            return View(sale);
        }

       
        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = SD.PayrollSpecalist)]
        public IActionResult ShopBonus(decimal requiredSalary, decimal bonus, SaleVM saleVM, int bonusform)
        {
            //if (!ModelState.IsValid || requiredSalary == 0 || bonusform != 1 || bonusform != 0)
            //{
            //    return View(saleVM);
            //}
            List<WorkerBonus> addBonus = new List<WorkerBonus>();
            List<Shop> shops = new List<Shop>();
            List<Worker> workers = new List<Worker>();

            foreach (var item in saleVM.AvialableShops)
            {
                if (item.SaleSalary >= requiredSalary)
                {
                    var shop = _context.Shops.Where(x => x.ID == item.ShopId).ToList();
                    shops.AddRange(shop);
                }
            }

            foreach (var shop in shops)
            {
                var work = _context.Users.Where(x=>x.Worked==true).Include(x => x.Position).Where(x => x.ShopId == shop.ID).ToList();
                workers.AddRange(work);
            }

            foreach (var work in workers)
            {
                if (bonusform == 1)
                {
                    addBonus.Add(new WorkerBonus { BonusDate = DateTime.Now, BonusSalary = bonus, Reason = "For great shopping", WorkerId = work.Id });
                }
                else
                    if (bonusform == 0)
                {
                    addBonus.Add(new WorkerBonus { BonusDate = DateTime.Now, BonusSalary = (work.Position.Salary) / 100 * bonus, Reason = "For great shopping", WorkerId = work.Id });
                }
            }

            _context.WorkerBonus.AddRange(addBonus);
            _context.SaveChanges();
            return RedirectToAction("List", "Shop");
        }
    }
}