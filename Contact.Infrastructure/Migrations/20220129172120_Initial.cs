using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Contact.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilgiTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilgiTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Firma = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KisiIletisim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KisiId = table.Column<Guid>(type: "uuid", nullable: false),
                    BilgiTipId = table.Column<int>(type: "integer", nullable: false),
                    Deger = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiIletisim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KisiIletisim_BilgiTip_BilgiTipId",
                        column: x => x.BilgiTipId,
                        principalTable: "BilgiTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KisiIletisim_Kisi_KisiId",
                        column: x => x.KisiId,
                        principalTable: "Kisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad",
                table: "BilgiTip",
                column: "Ad");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_Soyad",
                table: "Kisi",
                columns: new[] { "Ad", "Soyad" });

            migrationBuilder.CreateIndex(
                name: "IX_KisiIletisim_KisiId",
                table: "KisiIletisim",
                column: "KisiId");

            migrationBuilder.CreateIndex(
                name: "UIX_BilgiTipId_KisiId",
                table: "KisiIletisim",
                columns: new[] { "BilgiTipId", "KisiId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisiIletisim");

            migrationBuilder.DropTable(
                name: "BilgiTip");

            migrationBuilder.DropTable(
                name: "Kisi");
        }
    }
}
