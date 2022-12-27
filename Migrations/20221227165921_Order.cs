using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    clientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    firstName = table.Column<string>(type: "TEXT", nullable: true),
                    lastName = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    phoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItem_CatalogueItemId",
                table: "OrderedItem",
                column: "CatalogueItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItem_LocationId",
                table: "OrderedItem",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItem_OrderId",
                table: "OrderedItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "customerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItem_CatalogueItem_CatalogueItemId",
                table: "OrderedItem",
                column: "CatalogueItemId",
                principalTable: "CatalogueItem",
                principalColumn: "CatalogueItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItem_Locations_LocationId",
                table: "OrderedItem",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItem_Order_OrderId",
                table: "OrderedItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItem_CatalogueItem_CatalogueItemId",
                table: "OrderedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItem_Locations_LocationId",
                table: "OrderedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItem_Order_OrderId",
                table: "OrderedItem");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItem_CatalogueItemId",
                table: "OrderedItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItem_LocationId",
                table: "OrderedItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItem_OrderId",
                table: "OrderedItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeId",
                table: "Order");
        }
    }
}
