using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollSystem.Migrations
{
    public partial class Fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_MaritialStatuses_MaritalStatusId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "MaritialStatuses");

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    MaritalStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaritalStatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.MaritalStatusId);
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "MaritalStatusId", "MaritalStatusName" },
                values: new object[] { 1, "Married" });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "MaritalStatusId", "MaritalStatusName" },
                values: new object[] { 2, "Single" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_MaritalStatuses_MaritalStatusId",
                table: "Employees",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "MaritalStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_MaritalStatuses_MaritalStatusId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.CreateTable(
                name: "MaritialStatuses",
                columns: table => new
                {
                    MaritalStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaritalStatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritialStatuses", x => x.MaritalStatusId);
                });

            migrationBuilder.InsertData(
                table: "MaritialStatuses",
                columns: new[] { "MaritalStatusId", "MaritalStatusName" },
                values: new object[] { 1, "Married" });

            migrationBuilder.InsertData(
                table: "MaritialStatuses",
                columns: new[] { "MaritalStatusId", "MaritalStatusName" },
                values: new object[] { 2, "Single" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_MaritialStatuses_MaritalStatusId",
                table: "Employees",
                column: "MaritalStatusId",
                principalTable: "MaritialStatuses",
                principalColumn: "MaritalStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
