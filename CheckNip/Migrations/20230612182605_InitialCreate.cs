using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckNip.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestorationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasVirtualAccounts = table.Column<bool>(type: "bit", nullable: true),
                    StatusVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Krs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestorationBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDenialBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationLegalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovalBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDenialDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativesDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepresentativesDb_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_SubjectId",
                table: "BankAccounts",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SubjectId",
                table: "Persons",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativesDb_SubjectId",
                table: "RepresentativesDb",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RepresentativesDb");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
