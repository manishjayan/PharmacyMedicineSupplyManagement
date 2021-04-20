using Microsoft.VisualStudio.TestTools.UnitTesting;
using PharmacyMedicineSupply_Microservice.Controllers;
using PharmacyMedicineSupply_Microservice.Entity;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestProjectPharmacyMedicinesupplyMicroservice
{
    [TestClass]
    public class UnitTest1
    {
        //Negative test Expecting httpSession.RequestExcpetion when API not running on server
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task TestMethod_PostDemand()
        {
            //Arrange
            var controller = new PharmacySupplyController();
            List<MedicineDemand> inList = new List<MedicineDemand>()
            {
                new MedicineDemand{Medicine="Cyclopam",DemandCount=80},
                new MedicineDemand{Medicine="Dolo-650",DemandCount=120}
            };

            List<PharmacyMedicineSupply> outList = new List<PharmacyMedicineSupply>()
            {
                new PharmacyMedicineSupply(){Medicinename = "Gaviscon",Pharmacyname="R1",Supplycount = 120}
            };
            //Act

            var result = await controller.PostDemand(inList);

            //Assert
            Assert.AreEqual(outList.GetType(), result);
        }


        //Assert when api running will not throw http exception
        [TestMethod]
        public async Task TestMethod_PostDemandWhenaAPIRunning()
        {
            //Arrange
            var controller = new PharmacySupplyController();
            List<MedicineDemand> inList = new List<MedicineDemand>()
            {
                new MedicineDemand{Medicine="Cyclopam",DemandCount=80},
                new MedicineDemand{Medicine="Dolo-650",DemandCount=120}
            };

            List<PharmacyMedicineSupply> outList = new List<PharmacyMedicineSupply>()
            {
                new PharmacyMedicineSupply(){Medicinename = "Gaviscon",Pharmacyname="R1",Supplycount = 120}
            };
            //Act

            var result = await controller.PostDemand(inList);

            //Assert
            Assert.AreEqual(outList.GetType(), result);
        }
    }
}
