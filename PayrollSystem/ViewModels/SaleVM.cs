using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class SaleVM
    {
        [Required]
        public int ShopId { get; set; }
        public IEnumerable<Shop> Shops { get; set; }

        public List<AvialableShop> AvialableShops { get; set; }
    }
}
