using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class EmployeeLoginRequestModel
    {
        [Required(ErrorMessage = "Please enter your name!")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} charactors long", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
                "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
    }
}
