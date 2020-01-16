using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWPFApp.Models
{
    public class MortgageDataIn
    {
        public double LoanAmount { get; set; }
        public double AnnualRate { get; set; }
        public int DurationYears { get; set; }
        public int DurationMonths { get; set; }
        public Customer CustomerDetails { get; set; }
    }
}
