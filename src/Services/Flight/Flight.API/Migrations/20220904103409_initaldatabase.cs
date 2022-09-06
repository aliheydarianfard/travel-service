using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight.API.Migrations
{
    public partial class initaldatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Agency");

            migrationBuilder.EnsureSchema(
                name: "Flight");

            migrationBuilder.CreateSequence(
                name: "agency_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "agencyItem_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "flight_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "flightType_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Handler",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                schema: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agency_Handler_HandlerId",
                        column: x => x.HandlerId,
                        principalSchema: "Flight",
                        principalTable: "Handler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightItem",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlerId1 = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    HandlerId = table.Column<int>(type: "int", nullable: false),
                    Markup = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Minimumquantity = table.Column<int>(type: "int", nullable: false),
                    Remain = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightItem_Handler_HandlerId1",
                        column: x => x.HandlerId1,
                        principalSchema: "Flight",
                        principalTable: "Handler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgencyItems",
                schema: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    RequestedNumber = table.Column<int>(type: "int", nullable: false),
                    handlerItemId = table.Column<int>(type: "int", nullable: false),
                    HandlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyItems_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalSchema: "Agency",
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyItems_Handler_HandlerId",
                        column: x => x.HandlerId,
                        principalSchema: "Flight",
                        principalTable: "Handler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agency_HandlerId",
                schema: "Agency",
                table: "Agency",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyItems_AgencyId",
                schema: "Agency",
                table: "AgencyItems",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyItems_HandlerId",
                schema: "Agency",
                table: "AgencyItems",
                column: "HandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightItem_HandlerId1",
                schema: "Flight",
                table: "FlightItem",
                column: "HandlerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyItems",
                schema: "Agency");

            migrationBuilder.DropTable(
                name: "FlightItem",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Agency",
                schema: "Agency");

            migrationBuilder.DropTable(
                name: "Handler",
                schema: "Flight");

            migrationBuilder.DropSequence(
                name: "agency_hilo");

            migrationBuilder.DropSequence(
                name: "agencyItem_hilo");

            migrationBuilder.DropSequence(
                name: "flight_hilo");

            migrationBuilder.DropSequence(
                name: "flightType_hilo");
        }
    }
}
