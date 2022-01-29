using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Infrastructure.Migrations
{
    public partial class BilgiTipEnumIdEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BilgiTipEnumId",
                table: "BilgiTip",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BilgiTipEnumId",
                table: "BilgiTip");
        }
    }
}
