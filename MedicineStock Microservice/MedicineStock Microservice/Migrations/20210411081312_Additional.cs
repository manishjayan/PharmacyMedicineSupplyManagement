using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineStock_Microservice.Migrations
{
    public partial class Additional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Cholecalciferol",
                column: "NumberOfTabletsInStock",
                value: 5000);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Cyclopam",
                column: "NumberOfTabletsInStock",
                value: 12000);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Dolo-650",
                column: "NumberOfTabletsInStock",
                value: 8000);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Gaviscon",
                column: "NumberOfTabletsInStock",
                value: 2500);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Hilact",
                column: "NumberOfTabletsInStock",
                value: 6000);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Orthoherb",
                column: "NumberOfTabletsInStock",
                value: 10000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Cholecalciferol",
                column: "NumberOfTabletsInStock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Cyclopam",
                column: "NumberOfTabletsInStock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Dolo-650",
                column: "NumberOfTabletsInStock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Gaviscon",
                column: "NumberOfTabletsInStock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Hilact",
                column: "NumberOfTabletsInStock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MedicineStock",
                keyColumn: "Name",
                keyValue: "Orthoherb",
                column: "NumberOfTabletsInStock",
                value: 0);
        }
    }
}
