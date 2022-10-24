using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerInfrastructure.Migrations
{
    public partial class add_user_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Message",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Message",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Message");
        }
    }
}
