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
            migrationBuilder.CreateIndex(
                name: "IX_InventoryUsage_CatalogueItemId",
                table: "InventoryUsage",
                column: "CatalogueItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryUsage_ClientId",
                table: "InventoryUsage",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryUsage_ItemId",
                table: "InventoryUsage",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryUsage_CatalogueItem_CatalogueItemId",
                table: "InventoryUsage",
                column: "CatalogueItemId",
                principalTable: "CatalogueItem",
                principalColumn: "CatalogueItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryUsage_Client_ClientId",
                table: "InventoryUsage",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryUsage_Inventory_ItemId",
                table: "InventoryUsage",
                column: "ItemId",
                principalTable: "Inventory",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryUsage_CatalogueItem_CatalogueItemId",
                table: "InventoryUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryUsage_Client_ClientId",
                table: "InventoryUsage");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryUsage_Inventory_ItemId",
                table: "InventoryUsage");

            migrationBuilder.DropIndex(
                name: "IX_InventoryUsage_CatalogueItemId",
                table: "InventoryUsage");

            migrationBuilder.DropIndex(
                name: "IX_InventoryUsage_ClientId",
                table: "InventoryUsage");

            migrationBuilder.DropIndex(
                name: "IX_InventoryUsage_ItemId",
                table: "InventoryUsage");
        }
    }
}
