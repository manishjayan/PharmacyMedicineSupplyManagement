using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineStock_Microservice.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineStock",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChemicalComposition = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    TargetAilment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTabletsInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineStock", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "MedicineStock",
                columns: new[] { "Name", "ChemicalComposition", "DateOfExpiry", "NumberOfTabletsInStock", "TargetAilment" },
                values: new object[,]
                {
                    { "Orthoherb", "Castor Plant,Adulsa,Neem", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Orthopaedics" },
                    { "Cholecalciferol", "aspartame ,food dyes", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Orthopaedics" },
                    { "Gaviscon", "sodium alginate, sodium bicarbonate", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "General" },
                    { "Dolo-650", "Acetaminophen , Dexbrompheniramine", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "General" },
                    { "Cyclopam", "Dicyclomine  , Paracetamol ", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Gynaecology" },
                    { "Hilact", "Asparagus racemosus  , Anethum sowa ", new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Gynaecology" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineStock");
        }
    }
}
