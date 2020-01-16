using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWebApp.Models
{
    public class MortgageDataIn
    {
        [Required(ErrorMessage = "Loan amount is required")]
        [DisplayName("Loan Amount")]
        public double LoanAmount { get; set; }
        

        [Required(ErrorMessage = "Annual rate is required")]
        [DisplayName("Annual Rate")]
        public double AnnualRate { get; set; }

        [Required(ErrorMessage = "Duration Years is required")]
        [DisplayName("Duration Years")]
        public int DurationYears { get; set; }

        [Required(ErrorMessage = "Duration Months is required")]
        [DisplayName("Duration Months")]
        public int DurationMonths { get; set; }
        
        public Customer CustomerDetails { get; set; }
    }
}
