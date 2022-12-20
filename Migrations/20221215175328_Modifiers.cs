using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class Modifiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modifier",
                columns: table => new
                {
                    ModifierId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CatalogueItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceModifier = table.Column<int>(type: "INTEGER", nullable: false),
                    LoyaltyPointsModifier = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifier", x => x.ModifierId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modifier");
        }
    }
}
