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
        public async Task<ActionResult<IEnumerable<MedicineStock>>> GetMedicineStock()
        {
            return await _context.MedicineStock.ToListAsync();
        }

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
      //  GET: api/MedicineStockInformation/
    

        //// PUT: api/MedicineStockInformation/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMedicineStock(string id, MedicineStock medicineStock)
        //{
        //    if (id != medicineStock.Name)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(medicineStock).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MedicineStockExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/MedicineStockInformation
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<MedicineStock>> PostMedicineStock(MedicineStock medicineStock)
        //{
        //    _context.MedicineStock.Add(medicineStock);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (MedicineStockExists(medicineStock.Name))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetMedicineStock", new { id = medicineStock.Name }, medicineStock);
        //}

        //// DELETE: api/MedicineStockInformation/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMedicineStock(string id)
        //{
        //    var medicineStock = await _context.MedicineStock.FindAsync(id);
        //    if (medicineStock == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MedicineStock.Remove(medicineStock);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool MedicineStockExists(string id)
        //{
        //    return _context.MedicineStock.Any(e => e.Name == id);
        //}
    }
}
