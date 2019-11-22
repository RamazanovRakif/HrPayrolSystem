using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class WorkerAbsens
    {
        public int ID { get; set; }

        [Required]
        public string WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public int AbsenceId { get; set; }
        public virtual Absence Absence { get; set; }
        public int? Count { get; set; }
    }
}
