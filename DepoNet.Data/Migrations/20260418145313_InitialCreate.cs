using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepoNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depolar",
                columns: table => new
                {
                    DepoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depolar", x => x.DepoId);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    SiparisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.SiparisId);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.UrunId);
                });

            migrationBuilder.CreateTable(
                name: "BOMs",
                columns: table => new
                {
                    BOMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UstUrunId = table.Column<int>(type: "int", nullable: false),
                    AltUrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMs", x => x.BOMId);
                    table.ForeignKey(
                        name: "FK_BOMs_Urunler_AltUrunId",
                        column: x => x.AltUrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMs_Urunler_UstUrunId",
                        column: x => x.UstUrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetaylar",
                columns: table => new
                {
                    SiparisDetayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetaylar", x => x.SiparisDetayId);
                    table.ForeignKey(
                        name: "FK_SiparisDetaylar_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "SiparisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisDetaylar_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoklar",
                columns: table => new
                {
                    StokId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    DepoId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoklar", x => x.StokId);
                    table.ForeignKey(
                        name: "FK_Stoklar_Depolar_DepoId",
                        column: x => x.DepoId,
                        principalTable: "Depolar",
                        principalColumn: "DepoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stoklar_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StokHareketler",
                columns: table => new
                {
                    StokHareketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketler", x => x.StokHareketId);
                    table.ForeignKey(
                        name: "FK_StokHareketler_Stoklar_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoklar",
                        principalColumn: "StokId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_AltUrunId",
                table: "BOMs",
                column: "AltUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_UstUrunId",
                table: "BOMs",
                column: "UstUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_SiparisId",
                table: "SiparisDetaylar",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetaylar_UrunId",
                table: "SiparisDetaylar",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketler_StokId",
                table: "StokHareketler",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoklar_DepoId",
                table: "Stoklar",
                column: "DepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoklar_UrunId",
                table: "Stoklar",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOMs");

            migrationBuilder.DropTable(
                name: "SiparisDetaylar");

            migrationBuilder.DropTable(
                name: "StokHareketler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Stoklar");

            migrationBuilder.DropTable(
                name: "Depolar");

            migrationBuilder.DropTable(
                name: "Urunler");
        }
    }
}
