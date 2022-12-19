using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class Addconstrains2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_EmployeeId",
                table: "EmployeeShift",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ShiftId",
                table: "EmployeeShift",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCard_EmployeeId",
                table: "EmployeeCard",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCard_LocationId",
                table: "EmployeeCard",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LocationId",
                table: "Employee",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Locations_LocationId",
                table: "Employee",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCard_Employee_EmployeeId",
                table: "EmployeeCard",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCard_Locations_LocationId",
                table: "EmployeeCard",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShift_Employee_EmployeeId",
                table: "EmployeeShift",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShift_Shift_ShiftId",
                table: "EmployeeShift",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Locations_LocationId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCard_Employee_EmployeeId",
                table: "EmployeeCard");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCard_Locations_LocationId",
                table: "EmployeeCard");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShift_Employee_EmployeeId",
                table: "EmployeeShift");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShift_Shift_ShiftId",
                table: "EmployeeShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShift_EmployeeId",
                table: "EmployeeShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShift_ShiftId",
                table: "EmployeeShift");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeCard_EmployeeId",
                table: "EmployeeCard");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeCard_LocationId",
                table: "EmployeeCard");

            migrationBuilder.DropIndex(
                name: "IX_Employee_LocationId",
                table: "Employee");
        }
    }
}
