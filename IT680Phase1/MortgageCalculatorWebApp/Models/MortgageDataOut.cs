using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageCalculatorWebApp.Models
{
    public class MortgageDataOut
    {
        public MortgageDataIn InputedData { get; set; }
        [DataType(DataType.Currency)]
        public double MonthlyPayment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
