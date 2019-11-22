using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class SalaryViewModel
    {
        public string WorkerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDCardNumber { get; set; }
        public string IDCardFincode { get; set; }
        public string CardNumber { get; set; }
        public int CVC { get; set; }
        public decimal Balance { get; set; }
        public List<SelectedWorker>SelectedWorkers{ get; set; }
    }
}

