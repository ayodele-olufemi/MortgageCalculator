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
            double loanAmount = dataOut.InputedData.LoanAmount;
            for (int i = 1; i <= numberOfMonths; i++)
            {
                double monthlyInterest = loanAmount * dataOut.InputedData.AnnualRate / 1200;
                var thisPeriod = new AmortizationDataOut(i, dataOut.MonthlyPayment, monthlyInterest, dataOut.MonthlyPayment - monthlyInterest, loanAmount - dataOut.MonthlyPayment + monthlyInterest);
                loanAmount = loanAmount - dataOut.MonthlyPayment + monthlyInterest;
                result.Add(thisPeriod);
            }
            return result;
        }
    }
}