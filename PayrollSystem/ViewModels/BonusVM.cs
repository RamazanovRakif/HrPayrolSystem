using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class BonusVM
    {
        [Required]
        public string WorkerID { get; set; }

        public string WorkerAccount { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public DateTime BonusDate { get; set; }

        [Required]
        public decimal BonusSalary { get; set; }
    }
}
