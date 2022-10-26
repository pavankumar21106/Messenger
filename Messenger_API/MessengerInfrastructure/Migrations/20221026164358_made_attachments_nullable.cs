using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class made_attachments_nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachments",
                table: "Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "user",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(9653),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 24, 6, 26, 57, 533, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(8250),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 24, 6, 26, 57, 533, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "Message",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "user",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 24, 6, 26, 57, 533, DateTimeKind.Utc).AddTicks(2152),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 24, 6, 26, 57, 533, DateTimeKind.Utc).AddTicks(1084),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.AddColumn<string>(
                name: "Attachments",
                table: "Message",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
