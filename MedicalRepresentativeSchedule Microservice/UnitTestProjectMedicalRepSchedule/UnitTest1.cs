using MedicalRepresentativeSchedule_Microservice.Controllers;
using MedicalRepresentativeSchedule_Microservice.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestProjectMedicalRepSchedule
{
    [TestClass]
    public class UnitTest1
    {
        //This method will assert whether we are getting correct output type when passing correct date format
        //This is negative test are run only when API is not hosted as it will expect exception
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task TestMethod_Get()
        {
            //Arrange
            var controller = new RepScheduleController();
            List<RepSchedule> RepList = new List<RepSchedule>()
            {
                new RepSchedule(){Name = "R1",Dateofmeeting = System.DateTime.Now,Medicine=new List<string>{"Gavscon","Dolo-650"}
                ,Doctorname="D1",DoctorContactnumber="123456788",MeetingSlot="1PM to 2PM",TreatingAlignment="Orthopaedics"}
            };

            //Act
            var result = await controller.Get(System.DateTime.Now);

            //Assert
            Assert.AreEqual(RepList.GetType(), result.GetType());


        }

        //Positive testing. Shows Okay when API hosted and it checks data type of returned response matches as expected.
        [TestMethod]
        public async Task TestMethod_GetWithoutHttpRequestException()
        {
            //Arrange
            var controller = new RepScheduleController();
            List<RepSchedule> RepList = new List<RepSchedule>()
            {
                new RepSchedule(){Name = "R1",Dateofmeeting = System.DateTime.Now,Medicine=new List<string>{"Gavscon","Dolo-650"}
                ,Doctorname="D1",DoctorContactnumber="123456788",MeetingSlot="1PM to 2PM",TreatingAlignment="Orthopaedics"}
            };

            //Act
            var result = await controller.Get(System.DateTime.Now);

            //Assert
            Assert.AreEqual(RepList.GetType(), result.GetType());


        }
    }
}
