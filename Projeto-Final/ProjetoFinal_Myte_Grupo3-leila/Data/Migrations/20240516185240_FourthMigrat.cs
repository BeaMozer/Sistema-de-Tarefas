using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal_Myte_Grupo3.Data.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "WBS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorasTrabalhadas = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.RegisterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WBS_RegisterId",
                table: "WBS",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RegisterId",
                table: "Employee",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_RegisterId",
                table: "Department",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Register_RegisterId",
                table: "Department",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Register_RegisterId",
                table: "Employee",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_WBS_Register_RegisterId",
                table: "WBS",
                column: "RegisterId",
                principalTable: "Register",
                principalColumn: "RegisterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Register_RegisterId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Register_RegisterId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_WBS_Register_RegisterId",
                table: "WBS");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropIndex(
                name: "IX_WBS_RegisterId",
                table: "WBS");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RegisterId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Department_RegisterId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "WBS");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Department");
        }
    }
}
