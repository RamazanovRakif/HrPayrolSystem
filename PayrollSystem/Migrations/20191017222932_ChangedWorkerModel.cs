using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollSystem.Migrations
{
    public partial class ChangedWorkerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "WorkerAbsens",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Worked",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "WorkerAbsens");

            migrationBuilder.DropColumn(
                name: "Worked",
                table: "AspNetUsers");
        }
    }
}
