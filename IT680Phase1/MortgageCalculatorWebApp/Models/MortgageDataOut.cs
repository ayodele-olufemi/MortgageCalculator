using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWebApp.Models
{
    public class MortgageDataOut
    {
        public MortgageDataIn InputedData { get; set; }
        public double MonthlyPayment { get; set; }
        public double TotalInterest { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
