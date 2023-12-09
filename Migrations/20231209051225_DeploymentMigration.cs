using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csci340_iseegreen.Migrations
{
    /// <inheritdoc />
    public partial class DeploymentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    APG4sort = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "ISeeGreenUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISeeGreenUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxonomicOrders",
                columns: table => new
                {
                    TaxonomicOrder = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SortLevel1Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortLevel1 = table.Column<int>(type: "int", nullable: false),
                    SortLevel2Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortLevel2 = table.Column<int>(type: "int", nullable: false),
                    SortLevel3Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortLevel3 = table.Column<int>(type: "int", nullable: false),
                    SortLevel4Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortLevel4 = table.Column<int>(type: "int", nullable: false),
                    SortLevel5Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortLevel5 = table.Column<int>(type: "int", nullable: false),
                    SortLevel6Heading = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SortLevel6 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxonomicOrders", x => x.TaxonomicOrder);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ISeeGreenUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ISeeGreenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ISeeGreenUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ISeeGreenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ISeeGreenUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ISeeGreenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ISeeGreenUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ISeeGreenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                name: "Families",
                columns: table => new
                {
                    Family = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TranslateTo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaxonomicOrderID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Family);
                    table.ForeignKey(
                        name: "FK_Families_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Category");
                    table.ForeignKey(
                        name: "FK_Families_TaxonomicOrders_TaxonomicOrderID",
                        column: x => x.TaxonomicOrderID,
                        principalTable: "TaxonomicOrders",
                        principalColumn: "TaxonomicOrder");
                });

            migrationBuilder.CreateTable(
                name: "Genera",
                columns: table => new
                {
                    GenusID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KewID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FamilyID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genera", x => x.GenusID);
                    table.ForeignKey(
                        name: "FK_Genera_Families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Families",
                        principalColumn: "Family");
                });

            migrationBuilder.CreateTable(
                name: "Taxa",
                columns: table => new
                {
                    KewID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GenusID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecificEpithet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InfraspecificEpithet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaxonRank = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HybridGenus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HybridSpecies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Authors = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    USDAsymbol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    USDAsynonym = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxa", x => x.KewID);
                    table.ForeignKey(
                        name: "FK_Taxa_Genera_GenusID",
                        column: x => x.GenusID,
                        principalTable: "Genera",
                        principalColumn: "GenusID");
                });

            migrationBuilder.CreateTable(
                name: "ListItems",
                columns: table => new
                {
                    KewID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ListID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", maxLength: 255, nullable: true),
                    TimeDiscovered = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Synonyms",
                columns: table => new
                {
                    KewID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TaxaID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Genus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Species = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InfraspecificEpithet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TaxonRank = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Authors = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synonyms", x => x.KewID);
                    table.ForeignKey(
                        name: "FK_Synonyms_Taxa_TaxaID",
                        column: x => x.TaxaID,
                        principalTable: "Taxa",
                        principalColumn: "KewID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_CategoryID",
                table: "Families",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Families_TaxonomicOrderID",
                table: "Families",
                column: "TaxonomicOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Genera_FamilyID",
                table: "Genera",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ISeeGreenUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ISeeGreenUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Synonyms_TaxaID",
                table: "Synonyms",
                column: "TaxaID");

            migrationBuilder.CreateIndex(
                name: "IX_Taxa_GenusID",
                table: "Taxa",
                column: "GenusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ListItems");

            migrationBuilder.DropTable(
                name: "Synonyms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Taxa");

            migrationBuilder.DropTable(
                name: "ISeeGreenUsers");

            migrationBuilder.DropTable(
                name: "Genera");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TaxonomicOrders");
        }
    }
}
