using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public decimal SaleSalary { get; set; }
        public DateTime Date { get; set; }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
