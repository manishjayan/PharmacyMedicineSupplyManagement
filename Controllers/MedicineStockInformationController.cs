//This is the main controller for the Microservice.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MedicineStock_Microservice.Entity;
using MedicineStock_Microservice.DAL;

namespace MedicineStock_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineStockInformationController : ControllerBase
    {

        MedicineStokeRespo respository = new MedicineStokeRespo();
        // GET: api/MedicineStockInformation
        [HttpGet]
        public IEnumerable<MedicineStock> GetMedicineStock()
        {
            //Return List of all MedicineStoke
            return respository.GetAllStokeDetails();
        }



    }
}
