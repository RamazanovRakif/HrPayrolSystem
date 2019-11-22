using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class CompanyWorkPlace
    {
        public string ID { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public DateTime ChangedDate { get; set; }

        public virtual ICollection<CompanyWorkPlaceBonus> CompanyWorkPlaceBonus { get; set; }

        public virtual ICollection<CompanyWorkPlaceAbsence> CompanyWorkPlaceAbsences { get; set; }

        [Required]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

    }
}
