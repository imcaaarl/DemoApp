using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSvc.Migrations
{
    /// <inheritdoc />
    public partial class alterUserTypeRelationship_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        }
    }
}
