using Microsoft.EntityFrameworkCore.Migrations;

namespace NCCWebApp.Data.Migrations
{
    public partial class CreateNewUserSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "AspNetUsers");
        }
    }
}
