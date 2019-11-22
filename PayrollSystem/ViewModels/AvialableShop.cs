using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class AvialableShop
    {
        [Required]
        public int ShopId { get; set; }
        public IEnumerable<Shop> Shops { get; set; }

        [Required]
        public decimal SaleSalary { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime SelectedDate { get; set; }

        [Required]
        public string ShopName { get; set; }
    }
}
