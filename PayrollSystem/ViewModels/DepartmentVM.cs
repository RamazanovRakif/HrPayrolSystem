using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        public IEnumerable<Company> Companies { get; set; }

        public Company Company { get; set; }

        [Required(ErrorMessage = "!!!")]
        public int SelectedCompany { get; set; }

        [Required(ErrorMessage = "!!!")]
        public string Name { get; set; }

        public string CompanyName { get; set; }
    }
}
