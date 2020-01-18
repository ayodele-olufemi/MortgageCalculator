using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWebApp.Models
{
    public class AmortizationDataOut
    {
        public AmortizationDataOut(int months, double amount, double interest, double principal, double balance)
        {
            Months = months;
            Amount = amount;
            Interest = interest;
            Principal = principal;
            Balance = balance;
        }
        public int Months { get; set; }
        public double Amount { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
        public double Balance { get; set; }
    }
}
