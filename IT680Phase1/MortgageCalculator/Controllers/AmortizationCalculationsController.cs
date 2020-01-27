using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageCalculator.Models;

namespace MortgageCalculator.Controllers
{
    
    [ApiController]
    public class AmortizationCalculationsController : ControllerBase
    {
        [Route("PrintAmortization")]
        [HttpPost]
        public ActionResult<List<AmortizationDataOut>> GetAmortizationTable(MortgageDataOut dataOut)
        {
            List<AmortizationDataOut> result = new List<AmortizationDataOut>();
            var numberOfMonths = (dataOut.InputedData.DurationYears * 12) + dataOut.InputedData.DurationMonths;
            double loanAmount = dataOut.InputedData.LoanAmount - dataOut.InputedData.DownPayment;
            for (int i = 1; i <= numberOfMonths; i++)
            {
                double monthlyInterest = Math.Round(loanAmount * dataOut.InputedData.AnnualRate / 1200, 2);
                var thisPeriod = new AmortizationDataOut(i, dataOut.MonthlyPayment, monthlyInterest, Math.Round(dataOut.MonthlyPayment - monthlyInterest, 2), Math.Round(loanAmount - dataOut.MonthlyPayment + monthlyInterest, 2));
                loanAmount = Math.Round(loanAmount - dataOut.MonthlyPayment + monthlyInterest, 2);
                if(thisPeriod.Balance < 0)
                {
                    result.Add(thisPeriod);
                    break;
                }
                result.Add(thisPeriod);
            }
            if(result.Count > 0)
            {
                result[result.Count - 1].Amount = result[result.Count - 1].Interest + result[result.Count - 2].Balance;
                result[result.Count - 1].Principal = result[result.Count - 2].Balance;
               result[result.Count - 1].Balance = 0.00;
            }
            return result;
        }
    }
}