using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight.API.Migrations
{
    public partial class initaldatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Flight");

            migrationBuilder.CreateSequence(
                name: "flight_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "handler_hilo",
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
                name: "FlightItem",
                schema: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HandlerId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Markup = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remain = table.Column<int>(type: "int", nullable: false),
                    StockThreshold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightItem_Handler_HandlerId",
                        column: x => x.HandlerId,
                        principalSchema: "Flight",
                        principalTable: "Handler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightItem_HandlerId",
                schema: "Flight",
                table: "FlightItem",
                column: "HandlerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightItem",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Handler",
                schema: "Flight");

            migrationBuilder.DropSequence(
                name: "flight_hilo");

            migrationBuilder.DropSequence(
                name: "handler_hilo");
        }
    }
}
