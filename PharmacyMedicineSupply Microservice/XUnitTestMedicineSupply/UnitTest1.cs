using Moq;
using PharmacyMedicineSupply_Microservice.Controllers;
using PharmacyMedicineSupply_Microservice.Entity;
using PharmacyMedicineSupply_Microservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestMedicineSupply
{
  
    public class UnitTest1
    {
       /* private static List<MedicineDemand> CreateData()
        {
            return new List<MedicineDemand>()
            {
                new MedicineDemand{Medicine="Cyclopam",DemandCount=80},
                new MedicineDemand{Medicine="Dolo-650",DemandCount=120}
            };
        }

        public  async Task<IEnumerable<PharmacyMedicineSupply>> ResponseList()
        {
            await Task.Run(() => {

                IEnumerable<PharmacyMedicineSupply> db = new List<PharmacyMedicineSupply>()
            {
            new PharmacyMedicineSupply(){
                Pharmacyname = "Pharmacy1",
                Medicinename = "Cyclopam",
                Supplycount = 26
            },
            new PharmacyMedicineSupply(){
                Pharmacyname = "Pharmacy1",
                Medicinename = "Dolo-650",
                Supplycount = 40
            },
            new PharmacyMedicineSupply(){
                Pharmacyname = "Pharmacy2",
                Medicinename = "Cyclopam",
                Supplycount = 26
            },
            new PharmacyMedicineSupply(){
                Pharmacyname = "Pharmacy2",
                Medicinename ="Dolo-650",
                Supplycount = 40
            },
            new PharmacyMedicineSupply(){
                Pharmacyname = "Pharmacy3",
                Medicinename = "Cyclopam",
                Supplycount = 26
            },
            new PharmacyMedicineSupply(){
                Pharmacyname = "Pharmacy3",
                Medicinename = "Dolo-650",
                Supplycount = 40
            }
            };

                return db.ToList();
            });

            return null;
            
        }
        
        */
        [Fact]
        public async Task Test_GetMedicineDemandList_isReturnAsync()
        {
            //Arrange
            //var mock = new Mock<IMedicineSupplyRepo>();
           // Task<IEnumerable<PharmacyMedicineSupply>> list = ResponseList();
           // mock.Setup(p => p.PostDemand(CreateData())).Returns(list);
          
            PharmacySupplyController contrl = new PharmacySupplyController(mock.Object);

            var result = await contrl.PostDemand(CreateData());

            //Assert
            Assert.IsType<List<PharmacyMedicineSupply>>(result);

            
             
        }
    }
}
