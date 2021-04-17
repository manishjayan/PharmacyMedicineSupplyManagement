using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pharmacy_medicine_supply_Portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Pharmacy_medicine_supply_Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClientHandler handler = new HttpClientHandler();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Index(string UserName,string Password)
        {

            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // handler.UseDefaultCredentials = true;

            string apiResponse;
            using (var httpClient = new HttpClient(handler))//handler
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer ");
                using (var response = await httpClient.GetAsync($"http://localhost:5003/api/Authentication?Username={UserName}&Password={Password}"))
                {
                     apiResponse = await response.Content.ReadAsStringAsync();
                   // sheduleList = JsonConvert.DeserializeObject<List<RepSchedule>>(apiResponse);
                }
            }
            HttpContext.Session.SetString("Token", apiResponse);

            if(HttpContext.Session.GetString("Token") == "")
            {
                ViewBag.Message = "Invalid UserName or Password";
                return View();
            }

            return RedirectToAction("Schedule", "Home");
            
        }
        [HttpGet]
        public IActionResult Schedule()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Schedule(DateTime startDate)
        {
           
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // handler.UseDefaultCredentials = true;
            List<RepSchedule> sheduleList = new List<RepSchedule>();
            string apiResponse;
            using (var httpClient = new HttpClient(handler))//handler
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
                using (var response = await httpClient.GetAsync("http://localhost:5001/api/RepSchedule?startDate=" + startDate))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    sheduleList = JsonConvert.DeserializeObject<List<RepSchedule>>(apiResponse);
                }
            }
            if(apiResponse == "")
            {
                return PartialView("TimeOutView");
            }
           return PartialView("ScheduleView", sheduleList);
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
