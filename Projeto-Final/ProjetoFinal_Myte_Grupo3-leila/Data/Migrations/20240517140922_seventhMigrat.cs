using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal_Myte_Grupo3.Data.Migrations
{
    /// <inheritdoc />
    public partial class seventhMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorasTrabalhadas",
                table: "Register",
                newName: "WorkHours");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOfWeek",
                table: "Register",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Register");

            migrationBuilder.RenameColumn(
                name: "WorkHours",
                table: "Register",
                newName: "HorasTrabalhadas");
        }
    }
}
