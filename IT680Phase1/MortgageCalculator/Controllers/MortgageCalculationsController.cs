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
    public class MortgageCalculationsController : ControllerBase
    {
        [Route("CalculateMonthlyPayment")]
        [HttpGet]
        //public double CalculateMonthlyPayment(double loan, int lengthYears, int lengthMonths, double rate)
        public double CalculateMonthlyPayment(MortgageDataIn dataIn)
        {
            double monthlyInterestRate = dataIn.AnnualRate / 1200.0;
            int loanMonthsDuration = (dataIn.DurationYears * 12) + dataIn.DurationMonths;
            var monthlyPayment = ((dataIn.LoanAmount - dataIn.DownPayment) * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -1.0 * loanMonthsDuration));
            return Math.Round(monthlyPayment + dataIn.ExtraMonthlyPayment, 2);
        }

        [Route("CompareConfigurations")]
        [HttpPost]
        public ActionResult<List<MortgageDataOut>> CompareConfiguration(List<MortgageDataIn> dataIn)
        {
            List<MortgageDataOut> result = new List<MortgageDataOut>();
            foreach (MortgageDataIn data in dataIn)
            {
                result.Add(PrintResults(data).Value);
            };
            return result;
        }

        [HttpPost]
        [Route("PrintResults")]
        public ActionResult<MortgageDataOut> PrintResults(MortgageDataIn dataIn)
        {
            return new MortgageDataOut
            {
                MonthlyPayment = CalculateMonthlyPayment(dataIn),
                InputedData = dataIn
            };
        }
    }
}