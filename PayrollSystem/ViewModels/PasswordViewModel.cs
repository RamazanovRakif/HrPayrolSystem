using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.ViewModels
{
    public class PasswordViewModel
    {
        public string OldPassword { get; set; }
        [Required, StringLength(150), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, StringLength(150), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
