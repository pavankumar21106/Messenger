using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class testing_seeding_with_loop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5879), new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Attachment", "CreatedDate", "From", "FromName", "IsDeleted", "Message", "Title", "To", "ToName", "UpdatedDate" },
                values: new object[,]
                {
                    { 11, "11Attachments", new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5884), "11TestFrom@gmail.com", "11FromName", false, "11Message", "11Title", "11testTo@gmail.com", "11ToName", new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5884) },
                    { 12, "12Attachments", new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5887), "12TestFrom@gmail.com", "12FromName", false, "12Message", "12Title", "12testTo@gmail.com", "12ToName", new DateTime(2022, 10, 18, 14, 30, 49, 550, DateTimeKind.Utc).AddTicks(5888) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 15, 53, 213, DateTimeKind.Utc).AddTicks(9998), new DateTime(2022, 10, 18, 14, 15, 53, 214, DateTimeKind.Utc) });
        }
    }
}
