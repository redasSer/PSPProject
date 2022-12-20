using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class OrderedItemModifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderedItemModification",
                columns: table => new
                {
                    OrderedItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifierId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItemModification", x => new { x.OrderedItemId, x.ModifierId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedItemModification");
        }
    }
}
