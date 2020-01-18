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
        
        public async Task<IActionResult> CalculateMortgage(MortgageDataIn dataIn)
        {
            if (ModelState.IsValid)
            {
                MortgageDataOut result = new MortgageDataOut();
                var httpContent = new StringContent(JsonConvert.SerializeObject(dataIn), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsync("https://localhost:44322/printresults", httpContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<MortgageDataOut>(apiResponse);
                    }
                }
                return View(result);
            }
            return View("Index");
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
