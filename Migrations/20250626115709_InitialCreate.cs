using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VlammendVarkenBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergenen",
                columns: table => new
                {
                    allergeenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    symbool = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    beschrijving = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergenen", x => x.allergeenId);
                });

            migrationBuilder.CreateTable(
                name: "Bijgerechten",
                columns: table => new
                {
                    bijgerechtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prijs = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bijgerechten", x => x.bijgerechtId);
                });

            migrationBuilder.CreateTable(
                name: "Gerechten",
                columns: table => new
                {
                    gerechtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    soort = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerechten", x => x.gerechtId);
                });

            migrationBuilder.CreateTable(
                name: "Groenten",
                columns: table => new
                {
                    groenteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prijs = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groenten", x => x.groenteId);
                });

            migrationBuilder.CreateTable(
                name: "Hoofdonderdelen",
                columns: table => new
                {
                    hoofdonderdeelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prijs = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoofdonderdelen", x => x.hoofdonderdeelId);
                });

            migrationBuilder.CreateTable(
                name: "Levertijden",
                columns: table => new
                {
                    levertijdId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    minuten = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levertijden", x => x.levertijdId);
                });

            migrationBuilder.CreateTable(
                name: "Sausen",
                columns: table => new
                {
                    sausId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    prijs = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sausen", x => x.sausId);
                });

            migrationBuilder.CreateTable(
                name: "Tafels",
                columns: table => new
                {
                    TafelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nummer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tafels", x => x.TafelId);
                });

            migrationBuilder.CreateTable(
                name: "BijgerechtAllergenen",
                columns: table => new
                {
                    bijgerechtId = table.Column<int>(type: "INTEGER", nullable: false),
                    allergeenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BijgerechtAllergenen", x => new { x.bijgerechtId, x.allergeenId });
                    table.ForeignKey(
                        name: "FK_BijgerechtAllergenen_Allergenen_allergeenId",
                        column: x => x.allergeenId,
                        principalTable: "Allergenen",
                        principalColumn: "allergeenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BijgerechtAllergenen_Bijgerechten_bijgerechtId",
                        column: x => x.bijgerechtId,
                        principalTable: "Bijgerechten",
                        principalColumn: "bijgerechtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroenteAllergenen",
                columns: table => new
                {
                    groenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    allergeenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroenteAllergenen", x => new { x.groenteId, x.allergeenId });
                    table.ForeignKey(
                        name: "FK_GroenteAllergenen_Allergenen_allergeenId",
                        column: x => x.allergeenId,
                        principalTable: "Allergenen",
                        principalColumn: "allergeenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroenteAllergenen_Groenten_groenteId",
                        column: x => x.groenteId,
                        principalTable: "Groenten",
                        principalColumn: "groenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoofdonderdeelAllergenen",
                columns: table => new
                {
                    hoofdonderdeelId = table.Column<int>(type: "INTEGER", nullable: false),
                    allergeenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoofdonderdeelAllergenen", x => new { x.hoofdonderdeelId, x.allergeenId });
                    table.ForeignKey(
                        name: "FK_HoofdonderdeelAllergenen_Allergenen_allergeenId",
                        column: x => x.allergeenId,
                        principalTable: "Allergenen",
                        principalColumn: "allergeenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoofdonderdeelAllergenen_Hoofdonderdelen_hoofdonderdeelId",
                        column: x => x.hoofdonderdeelId,
                        principalTable: "Hoofdonderdelen",
                        principalColumn: "hoofdonderdeelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    bestellingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    levertijdId = table.Column<int>(type: "INTEGER", nullable: false),
                    besteldatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.bestellingId);
                    table.ForeignKey(
                        name: "FK_Bestellingen_Levertijden_levertijdId",
                        column: x => x.levertijdId,
                        principalTable: "Levertijden",
                        principalColumn: "levertijdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GerechtSamenstellingen",
                columns: table => new
                {
                    gerechtId = table.Column<int>(type: "INTEGER", nullable: false),
                    hoofdonderdeelId = table.Column<int>(type: "INTEGER", nullable: false),
                    bijgerechtId = table.Column<int>(type: "INTEGER", nullable: false),
                    groenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    sausId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerechtSamenstellingen", x => new { x.gerechtId, x.hoofdonderdeelId, x.bijgerechtId, x.groenteId, x.sausId });
                    table.ForeignKey(
                        name: "FK_GerechtSamenstellingen_Bijgerechten_bijgerechtId",
                        column: x => x.bijgerechtId,
                        principalTable: "Bijgerechten",
                        principalColumn: "bijgerechtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerechtSamenstellingen_Gerechten_gerechtId",
                        column: x => x.gerechtId,
                        principalTable: "Gerechten",
                        principalColumn: "gerechtId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerechtSamenstellingen_Groenten_groenteId",
                        column: x => x.groenteId,
                        principalTable: "Groenten",
                        principalColumn: "groenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerechtSamenstellingen_Hoofdonderdelen_hoofdonderdeelId",
                        column: x => x.hoofdonderdeelId,
                        principalTable: "Hoofdonderdelen",
                        principalColumn: "hoofdonderdeelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GerechtSamenstellingen_Sausen_sausId",
                        column: x => x.sausId,
                        principalTable: "Sausen",
                        principalColumn: "sausId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SausAllergenen",
                columns: table => new
                {
                    sausId = table.Column<int>(type: "INTEGER", nullable: false),
                    allergeenId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SausAllergenen", x => new { x.sausId, x.allergeenId });
                    table.ForeignKey(
                        name: "FK_SausAllergenen_Allergenen_allergeenId",
                        column: x => x.allergeenId,
                        principalTable: "Allergenen",
                        principalColumn: "allergeenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SausAllergenen_Sausen_sausId",
                        column: x => x.sausId,
                        principalTable: "Sausen",
                        principalColumn: "sausId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BestellingGerechten",
                columns: table => new
                {
                    bestellingId = table.Column<int>(type: "INTEGER", nullable: false),
                    gerechtId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellingGerechten", x => new { x.bestellingId, x.gerechtId });
                    table.ForeignKey(
                        name: "FK_BestellingGerechten_Bestellingen_bestellingId",
                        column: x => x.bestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "bestellingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellingGerechten_Gerechten_gerechtId",
                        column: x => x.gerechtId,
                        principalTable: "Gerechten",
                        principalColumn: "gerechtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BestellingTafels",
                columns: table => new
                {
                    bestellingId = table.Column<int>(type: "INTEGER", nullable: false),
                    tafelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellingTafels", x => new { x.bestellingId, x.tafelId });
                    table.ForeignKey(
                        name: "FK_BestellingTafels_Bestellingen_bestellingId",
                        column: x => x.bestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "bestellingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BestellingTafels_Tafels_tafelId",
                        column: x => x.tafelId,
                        principalTable: "Tafels",
                        principalColumn: "TafelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_levertijdId",
                table: "Bestellingen",
                column: "levertijdId");

            migrationBuilder.CreateIndex(
                name: "IX_BestellingGerechten_gerechtId",
                table: "BestellingGerechten",
                column: "gerechtId");

            migrationBuilder.CreateIndex(
                name: "IX_BestellingTafels_tafelId",
                table: "BestellingTafels",
                column: "tafelId");

            migrationBuilder.CreateIndex(
                name: "IX_BijgerechtAllergenen_allergeenId",
                table: "BijgerechtAllergenen",
                column: "allergeenId");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtSamenstellingen_bijgerechtId",
                table: "GerechtSamenstellingen",
                column: "bijgerechtId");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtSamenstellingen_groenteId",
                table: "GerechtSamenstellingen",
                column: "groenteId");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtSamenstellingen_hoofdonderdeelId",
                table: "GerechtSamenstellingen",
                column: "hoofdonderdeelId");

            migrationBuilder.CreateIndex(
                name: "IX_GerechtSamenstellingen_sausId",
                table: "GerechtSamenstellingen",
                column: "sausId");

            migrationBuilder.CreateIndex(
                name: "IX_GroenteAllergenen_allergeenId",
                table: "GroenteAllergenen",
                column: "allergeenId");

            migrationBuilder.CreateIndex(
                name: "IX_HoofdonderdeelAllergenen_allergeenId",
                table: "HoofdonderdeelAllergenen",
                column: "allergeenId");

            migrationBuilder.CreateIndex(
                name: "IX_SausAllergenen_allergeenId",
                table: "SausAllergenen",
                column: "allergeenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellingGerechten");

            migrationBuilder.DropTable(
                name: "BestellingTafels");

            migrationBuilder.DropTable(
                name: "BijgerechtAllergenen");

            migrationBuilder.DropTable(
                name: "GerechtSamenstellingen");

            migrationBuilder.DropTable(
                name: "GroenteAllergenen");

            migrationBuilder.DropTable(
                name: "HoofdonderdeelAllergenen");

            migrationBuilder.DropTable(
                name: "SausAllergenen");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Tafels");

            migrationBuilder.DropTable(
                name: "Bijgerechten");

            migrationBuilder.DropTable(
                name: "Gerechten");

            migrationBuilder.DropTable(
                name: "Groenten");

            migrationBuilder.DropTable(
                name: "Hoofdonderdelen");

            migrationBuilder.DropTable(
                name: "Allergenen");

            migrationBuilder.DropTable(
                name: "Sausen");

            migrationBuilder.DropTable(
                name: "Levertijden");
        }
    }
}
