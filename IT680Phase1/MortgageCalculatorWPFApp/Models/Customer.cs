using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWPFApp.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Middle name is required")]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
