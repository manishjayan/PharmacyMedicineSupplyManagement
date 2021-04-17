using PharmacyMedicineSupply_Microservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupply_Microservice.Repository
{
    public class MedicineSupplyRepo : IMedicineSupplyRepo
    {
        string[] PharmacyNames = new string[] { "Pharmacy1", "Pharmacy2", "Pharmacy3" };
        public  List<PharmacyMedicineSupply> PharmacysupplyList = new List<PharmacyMedicineSupply>();

        static List<MedicineStock> medicineList = new List<MedicineStock>()
        {
          
                  new MedicineStock() { Name = "Orthoherb",ChemicalComposition= "Castor Plant,Adulsa,Neem",TargetAilment= "Orthopaedics",DateOfExpiry=Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=10000 },
                  new MedicineStock() {Name = "Cholecalciferol", ChemicalComposition = "aspartame ,food dyes", TargetAilment = "Orthopaedics", DateOfExpiry = Convert.ToDateTime("2023-1-1") ,NumberOfTabletsInStock=5000},
                  new MedicineStock() {Name = "Gaviscon", ChemicalComposition= "sodium alginate, sodium bicarbonate", TargetAilment= "General", DateOfExpiry=Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=4000 },
                  new MedicineStock() { Name = "Dolo-650", ChemicalComposition = "Acetaminophen , Dexbrompheniramine", TargetAilment = "General", DateOfExpiry = Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=8000 },
                  new MedicineStock() { Name = "Cyclopam", ChemicalComposition = "Dicyclomine  , Paracetamol ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31") ,NumberOfTabletsInStock=12000},
                  new MedicineStock() { Name = "Hilact", ChemicalComposition = "Asparagus racemosus  , Anethum sowa ", TargetAilment = "Gynaecology", DateOfExpiry = Convert.ToDateTime("2022-12-31"),NumberOfTabletsInStock=6000 }

            
        };

 
        public async Task<IEnumerable<PharmacyMedicineSupply>> PostDemand(List<MedicineDemand> medicineDemands)
        {

            await Task.Run(() =>
            {

                for (int j = 0; j < medicineDemands.Count; j++)
                {
                    string medicineName = medicineDemands[j].Medicine;
                    int countofMedicine = medicineDemands[j].DemandCount;
                    for (int i = 0; i < PharmacyNames.Length; i++)
                    {
                        if (medicineList.Find(l => l.Name == medicineName) != null)
                        {
                            PharmacyMedicineSupply temp = new PharmacyMedicineSupply();
                            temp.Pharmacyname = PharmacyNames[i];
                            temp.Medicinename = medicineName;
                            temp.Supplycount = Convert.ToInt32(countofMedicine / PharmacyNames.Length);
                            if (i == 0)
                            {
                                temp.Supplycount += Convert.ToInt32(countofMedicine % PharmacyNames.Length);
                            }
                            PharmacysupplyList.Add(temp);
                        }
                    }
                }
                return PharmacysupplyList;
            });


            return null;

        }
    }
}
