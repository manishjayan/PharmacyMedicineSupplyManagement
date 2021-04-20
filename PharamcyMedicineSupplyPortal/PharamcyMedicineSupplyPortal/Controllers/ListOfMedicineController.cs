using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PharamcyMedicineSupplyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharamcyMedicineSupplyPortal.Controllers
{
    public class ListOfMedicineController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> MediList()
        {
            List <MedicineStock> cust = new List<MedicineStock>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/MedicineStockInformation"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cust = JsonConvert.DeserializeObject<List<MedicineStock>>(apiResponse);
                }
            }
            return View(cust);
        }
    }
}
