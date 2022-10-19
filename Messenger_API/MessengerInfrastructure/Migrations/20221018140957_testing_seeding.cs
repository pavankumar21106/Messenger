using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class testing_seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Attachments", "CreatedDate", "From", "FromName", "IsDeleted", "Message", "Title", "To", "ToName", "UpdatedDate" },
                values: new object[] { 10, "Attachments", new DateTime(2022, 10, 18, 14, 9, 57, 205, DateTimeKind.Utc).AddTicks(7749), "testFrom@gmail.com", "FromName", false, "Message", "Title", "testTo@gmail.com", "ToName", new DateTime(2022, 10, 18, 14, 9, 57, 205, DateTimeKind.Utc).AddTicks(7750) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
