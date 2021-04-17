using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace MedicineStock_Microservice.Entity
{
    public class DemandMedicine
    {
         public string Medicine { get; set; }
        public int DemandCount { get; set; }
    }
}
