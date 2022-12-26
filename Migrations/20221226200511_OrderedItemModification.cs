using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class OrderedItemModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderedItem",
                columns: table => new
                {
                    OrderedItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CatalogueItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Tax = table.Column<double>(type: "REAL", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItem", x => x.OrderedItemId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemModification_ModifierId",
                table: "OrderedItemModification",
                column: "ModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemModification_Modifier_ModifierId",
                table: "OrderedItemModification",
                column: "ModifierId",
                principalTable: "Modifier",
                principalColumn: "ModifierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemModification_OrderedItem_OrderedItemId",
                table: "OrderedItemModification",
                column: "OrderedItemId",
                principalTable: "OrderedItem",
                principalColumn: "OrderedItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemModification_Modifier_ModifierId",
                table: "OrderedItemModification");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemModification_OrderedItem_OrderedItemId",
                table: "OrderedItemModification");

            migrationBuilder.DropTable(
                name: "OrderedItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItemModification_ModifierId",
                table: "OrderedItemModification");
        }
    }
}
