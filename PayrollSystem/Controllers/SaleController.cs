using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;

namespace PayrollSystem.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly PayrollDbContext _context;
        public SaleController(PayrollDbContext context)
        {
            _context =context;
        }

        [Authorize(Roles = SD.Admin)]
        public IActionResult Create()
        {
            AvialableShop sale = new AvialableShop();
            sale.Shops = _context.Shops.ToList();
            return View(sale);
        }

        [Authorize(Roles = SD.Admin)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(AvialableShop shops)
        {
           
            Sale sale = new Sale();
            sale.ShopId = shops.ShopId;
            sale.SaleSalary = shops.SaleSalary;
            sale.Date = shops.Date;

            _context.Sales.Add(sale);
            _context.SaveChanges();

            return RedirectToAction("List", "Shop");
        }

        [Authorize(SD.PayrollSpecalist)]
        public IActionResult SaleForShop(string selectedDate)
        {
            if (selectedDate == null) return NotFound();
            
            DateTime date = Convert.ToDateTime(selectedDate);

            var storeSale = _context.Sales.Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month);

            var data = _context.Shops.Select(y => new AvialableShop
            {
                SaleSalary = _context.Sales.Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.ShopId == y.ID).Sum(x => x.SaleSalary),
                ShopName = y.Name,
                SelectedDate = date
            }).ToList();

            List<AvialableShop> sale = new List<AvialableShop>();

            foreach (var item in data)
            {
                sale.Add(new AvialableShop() { ShopName = item.ShopName, SaleSalary = item.SaleSalary, SelectedDate = item.SelectedDate });
            }
            return View(sale);
        }
    }
}