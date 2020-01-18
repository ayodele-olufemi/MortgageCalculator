using MortgageCalculatorWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWebApp.ViewModels
{
    public class MortgageAndAmortization
    {
        public MortgageDataOut MortOut { get; set; }
        public List<AmortizationDataOut> AmortOut { get; set; }
    }
}
