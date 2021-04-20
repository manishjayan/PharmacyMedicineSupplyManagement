using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharamcyMedicineSupplyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PharamcyMedicineSupplyPortal.Controllers
{
    public class ScheduleMeetingController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        [HttpGet]
        public IActionResult Schedule()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Schedule(DateTime date)
        {
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            string startDate = date.ToString("MM/dd/yyyy hh:mm tt");
            List<RepSchedule> sheduleList = new List<RepSchedule>();
            string apiResponse;
            using (var httpClient = new HttpClient(handler))//handler
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
                using (var response = await httpClient.GetAsync("http://localhost:5001/api/RepSchedule?startDate="+ startDate))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    sheduleList = JsonConvert.DeserializeObject<List<RepSchedule>>(apiResponse);
                }
            }
            if (apiResponse == "")
            {
                return RedirectToAction("Login","Dashboard");  //Session expired 
            }

            return View("GetListMeet", sheduleList);
        }
        [HttpGet]
        public IActionResult GetListMeet(List<RepSchedule> obj)
        {
            return View(obj);
        }

    }
}
