using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSvc.Migrations
{
    /// <inheritdoc />
    public partial class alterTblUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblusers_tbluserroles_UserRoleId",
                table: "tblusers");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "tblusers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblusers_tbluserroles_UserRoleId",
                table: "tblusers",
                column: "UserRoleId",
                principalTable: "tbluserroles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblusers_tbluserroles_UserRoleId",
                table: "tblusers");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "tblusers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblusers_tbluserroles_UserRoleId",
                table: "tblusers",
                column: "UserRoleId",
                principalTable: "tbluserroles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
