using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllRR.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProfilesControllx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_BusinessCompanies_BusinessCompanyId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessCompanyId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_BusinessCompanies_BusinessCompanyId",
                table: "Profiles",
                column: "BusinessCompanyId",
                principalTable: "BusinessCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_BusinessCompanies_BusinessCompanyId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "BusinessCompanyId",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_BusinessCompanies_BusinessCompanyId",
                table: "Profiles",
                column: "BusinessCompanyId",
                principalTable: "BusinessCompanies",
                principalColumn: "Id");
        }
    }
}
