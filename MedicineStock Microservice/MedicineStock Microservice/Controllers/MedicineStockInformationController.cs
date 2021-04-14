using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicineStock_Microservice.Entity;

namespace MedicineStock_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineStockInformationController : ControllerBase
    {
        private readonly MedicineStockContext _context;

        public MedicineStockInformationController(MedicineStockContext context)
        {
            _context = context;
        }

        // GET: api/MedicineStockInformation
        [HttpGet]
        public async Task<IEnumerable<MedicineStock>> GetMedicineStock()
        {
            return await _context.MedicineStock.ToListAsync();
        }

        [HttpGet("TreatingMedicineMap")]

        public async Task<List<TreatingAlimentMapMedicine>> GetAlimentAndMedicine()
        {
            List<TreatingAlimentMapMedicine> TreatingAlimentList = new List<TreatingAlimentMapMedicine>();
            List<MedicineStock> stockList= await _context.MedicineStock.ToListAsync();
            foreach(MedicineStock item in stockList)
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

        //HttpPUt method to get the stock and check the demand and update the stock.Call by PharamacyMedicineSupply Microservice
        [HttpPut("/Demand")] 
        public ActionResult<IEnumerable<DemandMedicine>> GetMedicineDemand(List<DemandMedicine> demandMedicine)
        {
            List<MedicineStock> alist=   _context.MedicineStock.ToList();
            List<DemandMedicine> responseList=new List<DemandMedicine>(); 
            
            foreach (DemandMedicine item in demandMedicine)
            {
                DemandMedicine dem=new DemandMedicine();
                dem.Medicine=item.Medicine;
                MedicineStock stoke=alist.Where(x=>x.Name == item.Medicine).First();
                dem.DemandCount=item.DemandCount > stoke.NumberOfTabletsInStock?stoke.NumberOfTabletsInStock:item.DemandCount;
                stoke.NumberOfTabletsInStock -=dem.DemandCount;
                responseList.Add(dem);
                _context.SaveChanges();
            }

            return  responseList;
        }
     
    }
}
