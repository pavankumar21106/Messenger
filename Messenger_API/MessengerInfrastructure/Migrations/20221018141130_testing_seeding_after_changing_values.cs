using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class testing_seeding_after_changing_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "From", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 11, 29, 888, DateTimeKind.Utc).AddTicks(9341), "TestFrom@gmail.com", new DateTime(2022, 10, 18, 14, 11, 29, 888, DateTimeKind.Utc).AddTicks(9343) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "From", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 9, 57, 205, DateTimeKind.Utc).AddTicks(7749), "testFrom@gmail.com", new DateTime(2022, 10, 18, 14, 9, 57, 205, DateTimeKind.Utc).AddTicks(7750) });
        }
    }
}
