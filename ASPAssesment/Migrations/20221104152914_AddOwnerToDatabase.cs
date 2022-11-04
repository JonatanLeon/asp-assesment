using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPAssesment.Migrations
{
    public partial class AddOwnerToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    driverLicense = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    brand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    vin = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    color = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    year = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    owner_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Owners",
                        column: x => x.owner_id,
                        principalTable: "Owners",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    vehicle_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_Claims_Vehicles",
                        column: x => x.vehicle_id,
                        principalTable: "Vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_vehicle_id",
                table: "Claims",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_owner_id",
                table: "Vehicles",
                column: "owner_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
