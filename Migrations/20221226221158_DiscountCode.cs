using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class DiscountCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountCode",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discount = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCode", x => new { x.Code, x.ClientId });
                    table.ForeignKey(
                        name: "FK_DiscountCode_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCode_ClientId",
                table: "DiscountCode",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountCode");
        }
    }
}
