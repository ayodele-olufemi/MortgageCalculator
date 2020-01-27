using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
        [DataType(DataType.Currency)]
        public double Interest { get; set; }
        [DataType(DataType.Currency)]
        public double Principal { get; set; }
        [DataType(DataType.Currency)]
        public double Balance { get; set; }
    }
}
