using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyMedicineSupply_Microservice.Entity;
using System.Net.Http;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmacyMedicineSupply_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacySupplyController : ControllerBase
    {
        string[] PharmacyNames = new string[] { "Pharmacy1", "Pharmacy2", "Pharmacy3" };
        List<PharmacyMedicineSupply> PharmacysupplyList = new List<PharmacyMedicineSupply>();
        
        HttpClientHandler handler = new HttpClientHandler();

        [HttpGet]
        public  List<string> Get()
        {
            List<string> alist = new List<string>();

            return  alist;
        }

        [HttpPost]
        public async Task<IEnumerable<PharmacyMedicineSupply>> Get([FromBody] List<MedicineDemand> medicineDemands)
        {
            IEnumerable<PharmacyMedicineSupply> resList = await PutDemand(medicineDemands);

            return   resList;
        }
        // GET: api/<PharmacySupplyController>
        [HttpPut]
        public async Task<IEnumerable<PharmacyMedicineSupply>> PutDemand(List<MedicineDemand> medicineDemands)
        {
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // handler.UseDefaultCredentials = true;
            List<MedicineDemand> medicineDeamndList = new List<MedicineDemand>();
            using (var httpClient = new HttpClient(handler))//handler
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(medicineDemands), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5000/Demand", content)) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    medicineDeamndList = JsonConvert.DeserializeObject<List<MedicineDemand>>(apiResponse);
                }
            }
            for(int i = 0;i < PharmacyNames.Length; i++)
                {
                foreach(MedicineDemand item in medicineDeamndList)
                {
                    PharmacyMedicineSupply temp = new PharmacyMedicineSupply();
                    temp.Pharmacyname = PharmacyNames[i];
                    temp.Medicinename = item.Medicine;
                    temp.Supplycount = Convert.ToInt32(item.DemandCount / PharmacyNames.Length);
                    PharmacysupplyList.Add(temp);
                }
                
            }
             return PharmacysupplyList;

        }

       
       

        // POST api/<PharmacySupplyController>
       

        // PUT api/<PharmacySupplyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PharmacySupplyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
