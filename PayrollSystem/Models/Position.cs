﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class Position
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
