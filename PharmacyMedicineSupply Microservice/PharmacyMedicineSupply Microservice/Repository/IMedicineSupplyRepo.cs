using PharmacyMedicineSupply_Microservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupply_Microservice.Repository
{
    public interface IMedicineSupplyRepo
    {
        IEnumerable<PharmacyMedicineSupply> PostDemand(List<MedicineDemand> medicineDemands);

        List<MedicineDemand> GetMedicineDemandList(List<MedicineDemand> medicineDemands);
    }
}
