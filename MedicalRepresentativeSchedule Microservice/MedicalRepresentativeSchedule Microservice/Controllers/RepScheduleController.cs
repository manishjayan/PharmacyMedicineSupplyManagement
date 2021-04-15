using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalRepresentativeSchedule_Microservice.Entity;
using System.Net.Http;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalRepresentativeSchedule_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepScheduleController : ControllerBase
    {
        HttpClientHandler handler = new HttpClientHandler();
        //List Of  Doctor Object Info.
        List<Doctor> DocList = new List<Doctor>() {
           new Doctor(){Name="D1",ContactNumber="9884122113",TreatingAlignment="Orthopaedics"},
           new Doctor(){Name="D2",ContactNumber="9884122113",TreatingAlignment="General"},
           new Doctor(){Name="D3",ContactNumber="9884122113",TreatingAlignment="General"},
           new Doctor(){Name="D4",ContactNumber="9884122113",TreatingAlignment="Orthopaedics"},
           new Doctor(){Name="D5",ContactNumber="9884122113",TreatingAlignment="Gynaecology"}
        };
        string[] representatives = new string[] { "R1", "R2", "R3" }; //List of representatives
     
        //Get the Repschedule of 5 days from start Date
        [HttpGet]
        public async Task<IEnumerable<RepSchedule>> Get(DateTime startDate)
        {
            List<TreatingAlimentMapMedicine> TList = await GetMedicineTreatingAlimentMap();//Return List Of trating aliment with Medicine Name
            List<RepSchedule> RepList = new List<RepSchedule>();

            for (int i = 0, j = 0; i < 5; i++, j++)
            {
                if (j == 3)  
                {
                    j = 0;
                }
                RepSchedule rep = new RepSchedule();
                if (startDate.DayOfWeek != DayOfWeek.Sunday) //Avoid Sundays
                {
                    rep.Doctorname = DocList[i].Name;
                    rep.DoctorContactnumber = DocList[i].ContactNumber;
                    rep.MeetingSlot = "1 PM-2 PM";
                    rep.Dateofmeeting = startDate.Date;
                    rep.Name = representatives[j];
                    rep.TreatingAlignment = DocList[i].TreatingAlignment;                  
                    var temp1 = TList.FirstOrDefault(x=>x.TreatingAliment== rep.TreatingAlignment); //Get the List of Medicine of  corresponding rep.TreatingAlignment
                    rep.Medicine = temp1.MedicineName;
                    RepList.Add(rep);
                } 
                else
                {
                    i--;
                    j--;
                }
                startDate = startDate.AddDays(1);

            }

            return RepList;
        }
        //Return List of TreatingAliment and corresponding list of medicine in that aliment
        [HttpGet("List")]
        public async Task<List<TreatingAlimentMapMedicine>> GetMedicineTreatingAlimentMap()
        {
            List<MedicineStock> stockList = new List<MedicineStock>();
            List<TreatingAlimentMapMedicine> TreatingAlimentList = new List<TreatingAlimentMapMedicine>();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // handler.UseDefaultCredentials = true;
           // List<TreatingAlimentMapMedicine> TreatringList = new List<TreatingAlimentMapMedicine>();
            using (var httpClient = new HttpClient(handler))//handler
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(medicineDemands), Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/MedicineStockInformation")) //Call the httpget of MedicineStokeInformation api to fetch  all Medicine stoke info.
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stockList = JsonConvert.DeserializeObject<List<MedicineStock>>(apiResponse);
                }
            }

            foreach (MedicineStock item in stockList)
            {
                TreatingAlimentMapMedicine obj = new TreatingAlimentMapMedicine();
                if (TreatingAlimentList.Find(x => x.TreatingAliment == item.TargetAilment) == null)
                {
                    obj.TreatingAliment = item.TargetAilment;
                    obj.MedicineName = stockList.Where(x => x.TargetAilment == obj.TreatingAliment).Select(y => y.Name).ToList();
                    TreatingAlimentList.Add(obj);
                }
            }

            return TreatingAlimentList;
        }
       
       
    }
}
