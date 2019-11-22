using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollSystem.Migrations
{
    public partial class ChangeCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Companies",
                maxLength: 200,
                nullable: true);
        }
    }
}
