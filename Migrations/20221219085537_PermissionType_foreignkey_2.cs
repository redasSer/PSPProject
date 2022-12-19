using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSP.Migrations
{
    /// <inheritdoc />
    public partial class PermissionTypeforeignkey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionTypeId",
                table: "Permission",
                column: "PermissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_PermissionType_PermissionTypeId",
                table: "Permission",
                column: "PermissionTypeId",
                principalTable: "PermissionType",
                principalColumn: "PermissionTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_PermissionType_PermissionTypeId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_PermissionTypeId",
                table: "Permission");
        }
    }
}
