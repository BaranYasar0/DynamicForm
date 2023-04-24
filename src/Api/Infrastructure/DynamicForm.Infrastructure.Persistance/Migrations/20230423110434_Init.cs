using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForm.Infrastructure.Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    DynamicFormApiDomainEntitiesForm_Id = table.Column<int>(name: "DynamicForm.Api.Domain.Entities.Form_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    C_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    U_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.DynamicFormApiDomainEntitiesForm_Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    DynamicFormApiDomainEntitiesField_Id = table.Column<int>(name: "DynamicForm.Api.Domain.Entities.Field_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Req = table.Column<bool>(type: "bit", nullable: false),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    F_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: true),
                    C_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    U_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.DynamicFormApiDomainEntitiesField_Id);
                    table.ForeignKey(
                        name: "FK_Field_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "DynamicForm.Api.Domain.Entities.Form_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Field_FormId",
                table: "Field",
                column: "FormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Form");
        }
    }
}
