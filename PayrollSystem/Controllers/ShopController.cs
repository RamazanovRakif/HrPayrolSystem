using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;
using static PayrollSystem.Extensions.IFormFileExtension;
using static PayrollSystem.Utilities.Utilities;

namespace PayrollSystem.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly PayrollDbContext _context;
        public ShopController(PayrollDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = SD.Admin)]
        public IActionResult Create()
        {
            ShopViewModel shop = new ShopViewModel();
            shop.Companies = _context.Companies.ToList();
            return View(shop);
        }

        [Authorize(Roles = SD.Admin)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ShopViewModel storeViewModel)
        {

            if (!ModelState.IsValid || storeViewModel.SelectedCompany == 0)
            {
                storeViewModel.Companies = _context.Companies.ToList();
                return View(storeViewModel);
            }
            Shop shop = new Shop();

            shop.CompanyId = storeViewModel.SelectedCompany;
            shop.Name = storeViewModel.Name;
            _context.Shops.Add(shop);
            _context.SaveChanges();

            return RedirectToAction(nameof(List));
        }

        [Authorize(Roles = "PayrollSpecalist,Admin")]
        [HttpGet]
        public async Task<IActionResult> List()
        {

            var shop = await _context.Shops.Select(x => new ShopViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Company = x.Company

            }).ToListAsync();

            return View(shop);
        }

        [Authorize(Roles = SD.Admin)]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var shop = _context.Shops.Find(id);

            ShopViewModel shopVM = new ShopViewModel();
            shopVM.Name = shop.Name;
            shopVM.Companies = _context.Companies.ToList();
            shopVM.CompanyName = shop.Company.Name;
            shopVM.ID = id;

            return View(shopVM);
        }

        [Authorize(Roles = SD.Admin)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ShopViewModel shopVM)
        {
            var store = _context.Shops.Find(id);

            if (!ModelState.IsValid)
            {
                shopVM.Companies = _context.Companies.ToList();
                shopVM.CompanyName = store.Company.Name;
                return View(shopVM);
            }

            store.Name = shopVM.Name;
            store.CompanyId = shopVM.SelectedCompany;
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [Authorize(Roles = SD.Admin)]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var shop = _context.Shops.Find(id);
            _context.Shops.Remove(shop);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }
        
    }
}