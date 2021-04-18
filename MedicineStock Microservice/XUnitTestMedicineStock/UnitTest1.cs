using MedicineStock_Microservice.Controllers;
using MedicineStock_Microservice.Entity;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestMedicineStock
{
    public class UnitTest1
    {

        [Fact]
        public void Test_GetMedicineStock_isReturnlist()
        {
            //Arrange
            var controller = new MedicineStockInformationController();

            //Act
            var data = controller.GetMedicineStock();

            //Assert
            Assert.IsType<List<MedicineStock>>(data);
        }
    }
}
