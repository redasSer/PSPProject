using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class Modifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Modifier_CatalogueItemId",
                table: "Modifier",
                column: "CatalogueItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_ClientId",
                table: "Modifier",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_ItemId",
                table: "Modifier",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modifier_CatalogueItem_CatalogueItemId",
                table: "Modifier",
                column: "CatalogueItemId",
                principalTable: "CatalogueItem",
                principalColumn: "CatalogueItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modifier_Client_ClientId",
                table: "Modifier",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modifier_Inventory_ItemId",
                table: "Modifier",
                column: "ItemId",
                principalTable: "Inventory",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modifier_CatalogueItem_CatalogueItemId",
                table: "Modifier");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifier_Client_ClientId",
                table: "Modifier");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifier_Inventory_ItemId",
                table: "Modifier");

            migrationBuilder.DropIndex(
                name: "IX_Modifier_CatalogueItemId",
                table: "Modifier");

            migrationBuilder.DropIndex(
                name: "IX_Modifier_ClientId",
                table: "Modifier");

            migrationBuilder.DropIndex(
                name: "IX_Modifier_ItemId",
                table: "Modifier");
        }
    }
}
