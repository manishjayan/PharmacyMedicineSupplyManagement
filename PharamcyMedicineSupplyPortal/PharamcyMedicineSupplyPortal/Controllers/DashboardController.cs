using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharamcyMedicineSupplyPortal.Controllers
{
    public class DashboardController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                HttpContext.Session.SetString("Token", "");
            }
            catch (System.NullReferenceException e)
            {

            }




            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
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

            if (HttpContext.Session.GetString("Token") == "")
            {
                ViewBag.Message = "Invalid UserName or Password";
                return View();
            }

            return RedirectToAction("Dashboard");

        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
