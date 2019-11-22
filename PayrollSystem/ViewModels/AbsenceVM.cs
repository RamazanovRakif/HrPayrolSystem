using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class AbsenceVM
    {
        [Required]
        public string WorkerId { get; set; }

        public string WorkerAccount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public int SelectedAbsence { get; set; }
        public IEnumerable<Absence> Absence { get; set; }

        public int AbsenceId { get; set; }
    }
}
