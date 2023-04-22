using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForm.Infrastructure.Persistance.Migrations
{
    public partial class Correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Form_Id",
                table: "Form",
                newName: "DynamicForm.Api.Domain.Entities.Form_Id");

            migrationBuilder.RenameColumn(
                name: "Form_Id",
                table: "Field",
                newName: "DynamicForm.Api.Domain.Entities.Field_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DynamicForm.Api.Domain.Entities.Form_Id",
                table: "Form",
                newName: "Form_Id");

            migrationBuilder.RenameColumn(
                name: "DynamicForm.Api.Domain.Entities.Field_Id",
                table: "Field",
                newName: "Form_Id");
        }
    }
}
