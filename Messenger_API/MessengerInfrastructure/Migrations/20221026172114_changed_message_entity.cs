using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class changed_message_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Message",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Message",
                newName: "Body");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "user",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 26, 17, 21, 14, 83, DateTimeKind.Utc).AddTicks(3100),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 26, 17, 21, 14, 83, DateTimeKind.Utc).AddTicks(1154),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(8250));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Message",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Message",
                newName: "Message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "user",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(9653),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 26, 17, 21, 14, 83, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Message",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2022, 10, 26, 16, 43, 58, 443, DateTimeKind.Utc).AddTicks(8250),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 10, 26, 17, 21, 14, 83, DateTimeKind.Utc).AddTicks(1154));
        }
    }
}
