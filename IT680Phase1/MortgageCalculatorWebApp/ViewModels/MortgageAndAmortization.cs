using MortgageCalculatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWebApp.ViewModels
{
    public class MortgageAndAmortization
    {
        public MortgageDataOut MortOut { get; set; }
        public List<AmortizationDataOut> AmortOut { get; set; }
        
        [DataType(DataType.Currency)]
        public double TotalInterest { get; set; }
        
        [DataType(DataType.Currency)]
        public double TotalSavings { get; set; }

        public int EarlierMonthsDifference { get; set; }
    }
}
