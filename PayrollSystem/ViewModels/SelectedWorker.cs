﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class SelectedWorker
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
        public decimal MonthlySalary { get; set; }

        public int ExcusableAbsens { get; set; }

        public int UnExcusableAbsens { get; set; }

        public int AbsensCount { get; set; }
        public decimal TotalSalary { get; set; }
        public string IDCardNumber { get; set; }
        public DateTime OldCalculate { get; set; }

        public bool IsChecked { get; set; }
    }
}
