using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyMedicineSupply_Microservice.Entity;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmacyMedicineSupply_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PharmacySupplyController : ControllerBase
    {
        string[] PharmacyNames = new string[] { "Pharmacy1", "Pharmacy2", "Pharmacy3" };
        List<PharmacyMedicineSupply> PharmacysupplyList = new List<PharmacyMedicineSupply>();
        
        HttpClientHandler handler = new HttpClientHandler();

       
        [HttpPost]
        public async Task<IEnumerable<PharmacyMedicineSupply>> PostDemand(List<MedicineDemand> medicineDemands)
        {
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            List<MedicineDemand> medicineDeamndList = await GetMedicineDemandList(medicineDemands);
            for (int i = 0;i < PharmacyNames.Length; i++)
                {
                foreach(MedicineDemand item in medicineDeamndList)
                {
                    PharmacyMedicineSupply temp = new PharmacyMedicineSupply();
                    temp.Pharmacyname = PharmacyNames[i];
                    temp.Medicinename = item.Medicine;
                    temp.Supplycount = Convert.ToInt32(item.DemandCount / PharmacyNames.Length);
                    if(i==0)
                    {
                         temp.Supplycount += Convert.ToInt32(item.DemandCount % PharmacyNames.Length);
                    }
                    PharmacysupplyList.Add(temp);
                }
                
            }
             return PharmacysupplyList;

        }
        [HttpGet]
        public async Task<List<MedicineDemand>> GetMedicineDemandList(List<MedicineDemand> medicineDemands)
        {
            List<MedicineStock> stockList = new List<MedicineStock>();
            List<MedicineDemand> medicineDeamndList = new List<MedicineDemand>();

            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
          
            using (var httpClient = new HttpClient(handler))//handler
            {
               
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/MedicineStockInformation")) //Call the httpget of MedicineStokeInformation api to fetch  all Medicine stoke info.
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stockList = JsonConvert.DeserializeObject<List<MedicineStock>>(apiResponse);
                }
            }

            foreach (MedicineDemand item in medicineDemands)
            {
                MedicineDemand dem = new MedicineDemand();
                dem.Medicine = item.Medicine;
                MedicineStock stoke = stockList.Where(x => x.Name == item.Medicine).First();
                dem.DemandCount = item.DemandCount > stoke.NumberOfTabletsInStock ? stoke.NumberOfTabletsInStock : item.DemandCount;
             
             
                medicineDeamndList.Add(dem);
               
            }


            return medicineDeamndList;
        }
       
       

     
    }
}
