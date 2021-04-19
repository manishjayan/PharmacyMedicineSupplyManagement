using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
    public class MedicineSupplyController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();
        public IActionResult InputDemand()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InputDemand([FromForm] IEnumerable<MedicineDemand> listOfMedicine)
        {


            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            List<PharmacyMedicineSupply> pharList = new List<PharmacyMedicineSupply>();
            string apiResponse;
            string che = "";
            using (var httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("Token"));
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(listOfMedicine), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://20.84.216.142/api/PharmacySupply/", content1))
                {
                    che = response.StatusCode.ToString();
                     apiResponse = await response.Content.ReadAsStringAsync();
                    pharList= JsonConvert.DeserializeObject<List<PharmacyMedicineSupply>>(apiResponse);
                }
            }
            if (che == "Unauthorized")
            {
                return PartialView("_Unauthorized");  //Session expired 
            }
            else if(che=="InternalServerError")
            {
                return PartialView("_InvalidData");
            }
            return PartialView("_InputDemand", pharList);
            
            }

        public IActionResult ListOfPharmacySupply(List<PharmacyMedicineSupply> phList)
        {
            return View(phList);
        }
    }
}
