using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Infrastructure.Migrations
{
    public partial class Raporeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rapor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RaporDurumEnumId = table.Column<int>(type: "integer", nullable: false),
                    RaporUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapor");
        }
    }
}
