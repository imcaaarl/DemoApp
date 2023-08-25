using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserSvc.Migrations
{
    /// <inheritdoc />
    public partial class addTableAndFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "tblusers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleCode",
                table: "tbluserroles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblusertypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserTypeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblusertypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tblusers_UserTypeId",
                table: "tblusers",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblusers_tblusertypes_UserTypeId",
                table: "tblusers",
                column: "UserTypeId",
                principalTable: "tblusertypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblusers_tblusertypes_UserTypeId",
                table: "tblusers");

            migrationBuilder.DropTable(
                name: "tblusertypes");

            migrationBuilder.DropIndex(
                name: "IX_tblusers_UserTypeId",
                table: "tblusers");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "tblusers");

            migrationBuilder.DropColumn(
                name: "UserRoleCode",
                table: "tbluserroles");
        }
    }
}
