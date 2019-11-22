using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.Models
{
    public class CompanyWorkPlaceAbsence // Iscinin vezifesini deyisende kohne vezifesindeki qayiblar
    {
        public string ID { get; set; }

        public string CompanyWorkPlaceId { get; set; }
        public virtual CompanyWorkPlace CompanyWorkPlace { get; set; }

        //uzrlu uzrsuz qayiblarin sayi 
        public int ExcusableAbsens { get; set; }
        public int UnExcusableAbsens { get; set; }
    }
}
