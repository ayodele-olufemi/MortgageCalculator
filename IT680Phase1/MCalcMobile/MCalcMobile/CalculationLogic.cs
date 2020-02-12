using System;
using System.Collections.Generic;
using System.Text;

namespace MCalcMobile
{
    public class CalculationLogic
    {
        public static double CalcMonthlyPayment(double loanAmount, double annualRate, int loanDurationYears, int loanDurationMonths, double downPayment, double extraMonthlyPayment)
        {
            double monthlyInterestRate = annualRate / 1200.0;
            int totalMonthsDuration = (loanDurationYears * 12) + loanDurationMonths;
            var monthlyPayment = ((loanAmount - downPayment) * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -1.0 * totalMonthsDuration));
            return Math.Round(monthlyPayment + extraMonthlyPayment, 2);
        }



        public List<AmortizationDataOut> GetAmortizationTable(double amountOfLoan, double annualRate, int loanDurationYears, int loanDurationMonths, double downPayment, double extraMonthlyPayment)
        {
            double monthlyPayment = CalcMonthlyPayment(amountOfLoan, annualRate, loanDurationYears, loanDurationMonths, downPayment, extraMonthlyPayment);
            
            List<AmortizationDataOut> result = new List<AmortizationDataOut>();


            var numberOfMonths = (loanDurationYears * 12) + loanDurationMonths;
            double loanAmount = amountOfLoan -downPayment;
            for (int i = 1; i <= numberOfMonths; i++)
            {
                double monthlyInterest = Math.Round(loanAmount * annualRate / 1200, 2);
                var thisPeriod = new AmortizationDataOut(i, monthlyPayment, monthlyInterest, Math.Round(monthlyPayment - monthlyInterest, 2), Math.Round(loanAmount - monthlyPayment + monthlyInterest, 2));
                loanAmount = Math.Round(loanAmount - monthlyPayment + monthlyInterest, 2);
                if (thisPeriod.Balance < 0)
                {
                    result.Add(thisPeriod);
                    break;
                }
                result.Add(thisPeriod);
            }
            if (result.Count > 0)
            {
                result[result.Count - 1].Amount = result[result.Count - 1].Interest + result[result.Count - 2].Balance;
                result[result.Count - 1].Principal = result[result.Count - 2].Balance;
                result[result.Count - 1].Balance = 0.00;
            }
            return result;
        }




    }
}
