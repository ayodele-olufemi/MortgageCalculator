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
        //[CompareLoanDownExtra("DownPayment", "ExtraMonthlyPayment", ErrorMessage = "Down Payment + Extra Monthly Payment cannot be greater than Loan Amount")]
        [Required(ErrorMessage = "Loan amount is required")]
        [Range(0,Double.MaxValue,ErrorMessage ="Enter a non-negative number")]
        [DisplayName("Loan Amount")]
        [DataType(DataType.Currency)]
        public double LoanAmount { get; set; }

        
        [Range(0, Double.MaxValue, ErrorMessage = "Enter a non-negative number")]
        [DisplayName("Down Payment")]
        [DataType(DataType.Currency)]
        public double DownPayment { get; set; } = 0.0;

        [Range(0, Double.MaxValue, ErrorMessage = "Enter a non-negative number")]
        [DisplayName("Extra Monthly Payment")]
        [DataType(DataType.Currency)]
        public double ExtraMonthlyPayment { get; set; } = 0.0;

        [Required(ErrorMessage = "Annual rate is required")]
        [DisplayName("Annual Rate")]
        public double AnnualRate { get; set; }

        [Required(ErrorMessage = "Duration Years is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter a whole number greater than or equals 1")]
        [DisplayName("Duration Years")]
        public int DurationYears { get; set; }

        [DisplayName("Duration Months")]
        public int DurationMonths { get; set; } = 0;
        
        public Customer CustomerDetails { get; set; }
    }
}
