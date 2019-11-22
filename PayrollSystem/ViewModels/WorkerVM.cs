using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class WorkerVM
    {
        public string WorkerId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public DateTime OldCalcdate { get; set; }
        public decimal TotalSalary { get; set; }
        public DateTime CalculatedDate { get; set; }
        public string Department { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public int SelectedEmployee { get; set; }

        [Required]
        public int SelectedPosition { get; set; }
        public IEnumerable<Position> Positions { get; set; }


        public IEnumerable<Shop> Shops { get; set; }
        public int? SelectedShop { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int SelectedDepartment { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public string Role { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime ChangedPositionDate { get; set; }

        public List<SelectedWorker> AvialableWorkers { get; set; }
    }
}
