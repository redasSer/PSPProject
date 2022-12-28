using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class CatalogueItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CatalogueItem_ClientId",
                table: "CatalogueItem",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogueItem_Client_ClientId",
                table: "CatalogueItem",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "clientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogueItem_Client_ClientId",
                table: "CatalogueItem");

            migrationBuilder.DropIndex(
                name: "IX_CatalogueItem_ClientId",
                table: "CatalogueItem");
        }
    }
}
