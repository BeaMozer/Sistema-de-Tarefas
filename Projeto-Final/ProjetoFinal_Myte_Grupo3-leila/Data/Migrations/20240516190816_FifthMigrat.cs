using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal_Myte_Grupo3.Data.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WBSId",
                table: "Register",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Register_EmployeeId",
                table: "Register",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Register_WBSId",
                table: "Register",
                column: "WBSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Employee_EmployeeId",
                table: "Register",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Register_WBS_WBSId",
                table: "Register",
                column: "WBSId",
                principalTable: "WBS",
                principalColumn: "WBSId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Employee_EmployeeId",
                table: "Register");

            migrationBuilder.DropForeignKey(
                name: "FK_Register_WBS_WBSId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_EmployeeId",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_WBSId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "WBSId",
                table: "Register");

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
    }
}
