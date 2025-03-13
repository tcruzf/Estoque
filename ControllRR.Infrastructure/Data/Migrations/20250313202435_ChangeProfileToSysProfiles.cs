using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllRR.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProfileToSysProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.CreateTable(
                name: "SysProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomePlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorPlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescricaoPlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasePlanoVelocidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilialPlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoConexao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciclo = table.Column<DateOnly>(type: "date", nullable: true),
                    Abreciclo = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento1 = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento2 = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento3 = table.Column<DateOnly>(type: "date", nullable: true),
                    Ultimafatura = table.Column<int>(type: "int", nullable: true),
                    Ultimocod = table.Column<int>(type: "int", nullable: true),
                    PadraoJuros = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PadraoMulta = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    BusinessCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysProfiles_BusinessCompanies_BusinessCompanyId",
                        column: x => x.BusinessCompanyId,
                        principalTable: "BusinessCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SysProfiles_BusinessCompanyId",
                table: "SysProfiles",
                column: "BusinessCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysProfiles");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BusinessCompanyId = table.Column<int>(type: "int", nullable: false),
                    Abreciclo = table.Column<DateOnly>(type: "date", nullable: true),
                    BasePlanoVelocidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciclo = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento1 = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento2 = table.Column<DateOnly>(type: "date", nullable: true),
                    DataVencimento3 = table.Column<DateOnly>(type: "date", nullable: true),
                    DescricaoPlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilialPlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomePlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PadraoJuros = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PadraoMulta = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    TipoConexao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ultimafatura = table.Column<int>(type: "int", nullable: true),
                    Ultimocod = table.Column<int>(type: "int", nullable: true),
                    ValorPlano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_BusinessCompanies_BusinessCompanyId",
                        column: x => x.BusinessCompanyId,
                        principalTable: "BusinessCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_BusinessCompanyId",
                table: "Profiles",
                column: "BusinessCompanyId");
        }
    }
}
