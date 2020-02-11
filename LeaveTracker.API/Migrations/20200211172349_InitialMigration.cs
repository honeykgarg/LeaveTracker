using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveTracker.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    EmailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    LeaveEntryId = table.Column<Guid>(nullable: false),
                    LeaveStartDate = table.Column<DateTime>(nullable: false),
                    LeaveEndDate = table.Column<DateTime>(nullable: false),
                    LeaveEntryAddedOrUpdatedTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    EmpId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.LeaveEntryId);
                    table.ForeignKey(
                        name: "FK_Leaves_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "EmailId", "Name" },
                values: new object[] { "1801942", "hkumar25@dxc.com", "Honey Kumar" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "EmailId", "Name" },
                values: new object[] { "1801943", "hkumar27@dxc.com", "Honey Garg" });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "LeaveEntryId", "EmpId", "LeaveEndDate", "LeaveEntryAddedOrUpdatedTime", "LeaveStartDate", "Status" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "1801942", new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 11, 22, 53, 48, 659, DateTimeKind.Local).AddTicks(8048), new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmpId",
                table: "Leaves",
                column: "EmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
