using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class testing_seeding_after_changing_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachments",
                table: "Message",
                newName: "Attachment");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Message",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 15, 53, 213, DateTimeKind.Utc).AddTicks(9998), new DateTime(2022, 10, 18, 14, 15, 53, 214, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attachment",
                table: "Message",
                newName: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Message",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 18, 14, 11, 29, 888, DateTimeKind.Utc).AddTicks(9341), new DateTime(2022, 10, 18, 14, 11, 29, 888, DateTimeKind.Utc).AddTicks(9343) });
        }
    }
}
