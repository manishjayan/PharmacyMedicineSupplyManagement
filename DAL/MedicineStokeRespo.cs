using MedicineStock_Microservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStock_Microservice.DAL
{
    public class MedicineStokeRespo
    {
        List<MedicineStock> medicineStock = new List<MedicineStock>()
        {

                 new MedicineStock() { Name = "Orthoherb",ChemicalComposition= "Castor Plant,Adulsa,Neem",TargetAilment= "Orthopaedics",DateOfExpiry=Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=10000 },
                 new MedicineStock() {Name = "Cholecalciferol", ChemicalComposition = "aspartame ,food dyes", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2023-1-1") ,NumberOfTabletsInStock=5000},
                 new MedicineStock() {Name = "Gaviscon", ChemicalComposition= "sodium alginate, sodium bicarbonate", TargetAilment= "General", DateOfExpiry=Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=4000 },
                 new MedicineStock() { Name = "Dolo-650", ChemicalComposition = "Acetaminophen , Dexbrompheniramine", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=8000 },
                 new MedicineStock() { Name = "Cyclopam", ChemicalComposition = "Dicyclomine  , Paracetamol ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31") ,NumberOfTabletsInStock=12000},
                 new MedicineStock() { Name = "Hilact", ChemicalComposition = "Asparagus racemosus  , Anethum sowa ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=6000 }



        };

        public List<MedicineStock> GetAllStokeDetails()
        {
            return medicineStock;
        }
    }
}
