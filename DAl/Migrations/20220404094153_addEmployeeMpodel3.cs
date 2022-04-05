using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Migrations
{
    public partial class addEmployeeMpodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_Dept_Id",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_Dept_Id",
                table: "Employees",
                column: "Dept_Id",
                principalTable: "departments",
                principalColumn: "Dept_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_Dept_Id",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Department");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_Dept_Id",
                table: "Employees",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Dept_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
