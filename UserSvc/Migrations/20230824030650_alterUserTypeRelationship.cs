using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSvc.Migrations
{
    /// <inheritdoc />
    public partial class alterUserTypeRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblusers_UserTypeId",
                table: "tblusers");

            migrationBuilder.CreateIndex(
                name: "IX_tblusers_UserTypeId",
                table: "tblusers",
                column: "UserTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblusers_tblusertypes_UserRoleId",
                table: "tblusers",
                column: "UserTypeId",
                principalTable: "tblusertypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblusers_UserTypeId",
                table: "tblusers");

            migrationBuilder.CreateIndex(
                name: "IX_tblusers_UserTypeId",
                table: "tblusers",
                column: "UserTypeId");
        }
    }
}
