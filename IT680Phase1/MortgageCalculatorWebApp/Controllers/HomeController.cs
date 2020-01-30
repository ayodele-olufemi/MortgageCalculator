using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MortgageCalculatorWebApp.Models;
using Newtonsoft.Json;
using System.Text;
using MortgageCalculatorWebApp.ViewModels;

namespace MortgageCalculatorWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CalculateMortgageAndAmortizationList(string dataIn)
        {
            List<MortgageDataIn> dataInList = JsonConvert.DeserializeObject<List<MortgageDataIn>>(dataIn);

            List<MortgageAndAmortization> results = new List<MortgageAndAmortization>();

            foreach (MortgageDataIn data in dataInList)
            {
                MortgageAndAmortization thisResult = new MortgageAndAmortization();
                var httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("https://localhost:44322/printresults", httpContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        thisResult.MortOut = JsonConvert.DeserializeObject<MortgageDataOut>(apiResponse);
                    }
                    var httpContent2 = new StringContent(JsonConvert.SerializeObject(thisResult.MortOut), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44322/printamortization", httpContent2))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        thisResult.AmortOut = JsonConvert.DeserializeObject<List<AmortizationDataOut>>(apiResponse);
                    }
                }
                var totalInterest = 0.0;
                foreach (var item in thisResult.AmortOut)
                {
                    totalInterest += item.Interest;
                }
                thisResult.TotalInterest = totalInterest;

                if ((data.DownPayment > 0) || (data.ExtraMonthlyPayment > 0))
                {
                    data.DownPayment = 0.0;
                    data.ExtraMonthlyPayment = 0.0;
                    MortgageAndAmortization resultWithoutSavings = new MortgageAndAmortization();
                    var httpContent3 = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.PostAsync("https://localhost:44322/printresults", httpContent3))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            resultWithoutSavings.MortOut = JsonConvert.DeserializeObject<MortgageDataOut>(apiResponse);
                        }
                        var httpContent4 = new StringContent(JsonConvert.SerializeObject(resultWithoutSavings.MortOut), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("https://localhost:44322/printamortization", httpContent4))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            resultWithoutSavings.AmortOut = JsonConvert.DeserializeObject<List<AmortizationDataOut>>(apiResponse);
                        }
                    }
                    var totalInterestWithoutSavings = 0.0;
                    foreach (var item in resultWithoutSavings.AmortOut)
                    {
                        totalInterestWithoutSavings += item.Interest;
                    }
                    resultWithoutSavings.TotalInterest = totalInterestWithoutSavings;
                    thisResult.TotalSavings = resultWithoutSavings.TotalInterest - thisResult.TotalInterest;
                    thisResult.EarlierMonthsDifference = resultWithoutSavings.AmortOut.Count() - thisResult.AmortOut.Count();
                }
                results.Add(thisResult);
            }
            return View(results);
        }


        public async Task<IActionResult> CalculateMortgageAndAmortization(MortgageDataIn dataIn)
        {
            if (ModelState.IsValid)
            {
                MortgageAndAmortization result = new MortgageAndAmortization();
                var httpContent = new StringContent(JsonConvert.SerializeObject(dataIn), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("https://localhost:44322/printresults", httpContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result.MortOut = JsonConvert.DeserializeObject<MortgageDataOut>(apiResponse);
                    }
                    var httpContent2 = new StringContent(JsonConvert.SerializeObject(result.MortOut), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:44322/printamortization", httpContent2))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result.AmortOut = JsonConvert.DeserializeObject<List<AmortizationDataOut>>(apiResponse);
                    }
                }  
                var totalInterest = 0.0;
                foreach(var item in result.AmortOut)
                {
                    totalInterest += item.Interest;
                }
                result.TotalInterest = totalInterest;

                if ((dataIn.DownPayment > 0) || (dataIn.ExtraMonthlyPayment > 0))
                {
                    dataIn.DownPayment = 0.0;
                    dataIn.ExtraMonthlyPayment = 0.0;
                    MortgageAndAmortization resultWithoutSavings = new MortgageAndAmortization();
                    var httpContent3 = new StringContent(JsonConvert.SerializeObject(dataIn), Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.PostAsync("https://localhost:44322/printresults", httpContent3))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            resultWithoutSavings.MortOut = JsonConvert.DeserializeObject<MortgageDataOut>(apiResponse);
                        }
                        var httpContent4 = new StringContent(JsonConvert.SerializeObject(resultWithoutSavings.MortOut), Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PostAsync("https://localhost:44322/printamortization", httpContent4))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            resultWithoutSavings.AmortOut = JsonConvert.DeserializeObject<List<AmortizationDataOut>>(apiResponse);
                        }
                    }
                    var totalInterestWithoutSavings = 0.0;
                    foreach (var item in resultWithoutSavings.AmortOut)
                    {
                        totalInterestWithoutSavings += item.Interest;
                    }
                    resultWithoutSavings.TotalInterest = totalInterestWithoutSavings;
                    result.TotalSavings = resultWithoutSavings.TotalInterest - result.TotalInterest;
                    result.EarlierMonthsDifference = resultWithoutSavings.AmortOut.Count() - result.AmortOut.Count();
                }

                return View(result);
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
