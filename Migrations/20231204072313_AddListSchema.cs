using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csci340_iseegreen.Migrations
{
    /// <inheritdoc />
    public partial class AddListSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    OwnerID = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_ISeeGreenUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ISeeGreenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerID = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_ISeeGreenUsers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ISeeGreenUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListItems",
                columns: table => new
                {
                    KewID = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ListID = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationID = table.Column<int>(type: "INTEGER", maxLength: 255, nullable: true),
                    TimeDiscovered = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItems", x => new { x.KewID, x.ListID });
                    table.ForeignKey(
                        name: "FK_ListItems_Lists_ListID",
                        column: x => x.ListID,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListItems_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListItems_Taxa_KewID",
                        column: x => x.KewID,
                        principalTable: "Taxa",
                        principalColumn: "KewID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_ListID",
                table: "ListItems",
                column: "ListID");

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_LocationID",
                table: "ListItems",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_OwnerID",
                table: "Lists",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OwnerID",
                table: "Locations",
                column: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItems");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
