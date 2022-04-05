using Microsoft.EntityFrameworkCore.Migrations;

namespace DAl.Migrations
{
    public partial class addEmployeeMpodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Dept_Id",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Dept_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dept_Id",
                table: "Employees",
                column: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_Dept_Id",
                table: "Employees",
                column: "Dept_Id",
                principalTable: "Department",
                principalColumn: "Dept_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_Dept_Id",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Dept_Id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Dept_Id",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
