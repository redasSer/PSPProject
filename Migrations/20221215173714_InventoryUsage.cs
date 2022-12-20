using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class InventoryUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryUsage",
                columns: table => new
                {
                    InventoryUsageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CatalogueItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryUsage", x => x.InventoryUsageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryUsage");
        }
    }
}
