using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class Absence
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<WorkerAbsens> WorkerAbsens { get; set; }
    }
}
