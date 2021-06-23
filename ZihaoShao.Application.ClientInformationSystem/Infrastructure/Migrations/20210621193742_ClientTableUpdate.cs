using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ClientTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Employees_AddedBy",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "AddedBy",
                table: "Clients",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_AddedBy",
                table: "Clients",
                newName: "IX_Clients_EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Employees_EmployeesId",
                table: "Clients",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Employees_EmployeesId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "Clients",
                newName: "AddedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_EmployeesId",
                table: "Clients",
                newName: "IX_Clients_AddedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Employees_AddedBy",
                table: "Clients",
                column: "AddedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
