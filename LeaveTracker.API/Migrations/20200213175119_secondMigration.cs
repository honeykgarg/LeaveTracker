using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveTracker.API.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Leaves",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Leaves",
                keyColumn: "LeaveEntryId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                columns: new[] { "LeaveEntryAddedOrUpdatedTime", "Status" },
                values: new object[] { new DateTime(2020, 2, 13, 23, 21, 18, 618, DateTimeKind.Local).AddTicks(6279), "Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Leaves",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Leaves",
                keyColumn: "LeaveEntryId",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                columns: new[] { "LeaveEntryAddedOrUpdatedTime", "Status" },
                values: new object[] { new DateTime(2020, 2, 11, 22, 53, 48, 659, DateTimeKind.Local).AddTicks(8048), 1 });
        }
    }
}
