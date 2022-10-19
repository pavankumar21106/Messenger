using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class testing_seeding_with_loop_changing_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 34, 15, 840, DateTimeKind.Utc).AddTicks(6802), new DateTime(2022, 10, 18, 14, 34, 15, 840, DateTimeKind.Utc).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ToName", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 34, 15, 840, DateTimeKind.Utc).AddTicks(6808), "1ToName", new DateTime(2022, 10, 18, 14, 34, 15, 840, DateTimeKind.Utc).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 34, 15, 840, DateTimeKind.Utc).AddTicks(6812), new DateTime(2022, 10, 18, 14, 34, 15, 840, DateTimeKind.Utc).AddTicks(6812) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5879), new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ToName", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5884), "11ToName", new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5887), new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5888) });
        }
    }
}
