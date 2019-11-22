using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class LoginVM
    {
        [Required, StringLength(80), EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(150), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
