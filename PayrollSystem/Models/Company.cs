using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OpenCompany { get; set; }

        [ StringLength(50)]
        public string Email { get; set; }

        [ StringLength(50)]
        public string TelNumber { get; set; }

        [StringLength(200)]
        public string Addres { get; set; }


        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
