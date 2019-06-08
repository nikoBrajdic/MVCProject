using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TKDLocalWebClient.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poomsaes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    Ordinal = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poomsaes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    IsFreestyle = table.Column<bool>(nullable: false),
                    CurrentRound = table.Column<int>(nullable: true),
                    Poomsae11ID = table.Column<int>(nullable: false),
                    Poomsae12ID = table.Column<int>(nullable: false),
                    Poomsae21ID = table.Column<int>(nullable: false),
                    Poomsae22ID = table.Column<int>(nullable: false),
                    Poomsae31ID = table.Column<int>(nullable: false),
                    Poomsae32ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Poomsaes_Poomsae11ID",
                        column: x => x.Poomsae11ID,
                        principalTable: "Poomsaes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Poomsaes_Poomsae12ID",
                        column: x => x.Poomsae12ID,
                        principalTable: "Poomsaes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Poomsaes_Poomsae21ID",
                        column: x => x.Poomsae21ID,
                        principalTable: "Poomsaes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Poomsaes_Poomsae22ID",
                        column: x => x.Poomsae22ID,
                        principalTable: "Poomsaes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Poomsaes_Poomsae31ID",
                        column: x => x.Poomsae31ID,
                        principalTable: "Poomsaes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Poomsaes_Poomsae32ID",
                        column: x => x.Poomsae32ID,
                        principalTable: "Poomsaes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contestants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    TrackPath = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contestants_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contestants_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Round = table.Column<int>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    MinorMean = table.Column<double>(nullable: false),
                    MinorTotal = table.Column<double>(nullable: false),
                    GrandTotal = table.Column<double>(nullable: false),
                    AccuracyMinorTotal = table.Column<double>(nullable: false),
                    PresentationMinorTotal = table.Column<double>(nullable: false),
                    AccuracyGrandTotal = table.Column<double>(nullable: false),
                    PresentationGrandTotal = table.Column<double>(nullable: false),
                    Presentation1 = table.Column<double>(nullable: false),
                    Presentation2 = table.Column<double>(nullable: false),
                    Presentation3 = table.Column<double>(nullable: false),
                    Presentation4 = table.Column<double>(nullable: false),
                    Presentation5 = table.Column<double>(nullable: false),
                    Presentation6 = table.Column<double>(nullable: false),
                    Presentation7 = table.Column<double>(nullable: false),
                    Presentation8 = table.Column<double>(nullable: false),
                    Presentation9 = table.Column<double>(nullable: false),
                    Accuracy1 = table.Column<double>(nullable: false),
                    Accuracy2 = table.Column<double>(nullable: false),
                    Accuracy3 = table.Column<double>(nullable: false),
                    Accuracy4 = table.Column<double>(nullable: false),
                    Accuracy5 = table.Column<double>(nullable: false),
                    Accuracy6 = table.Column<double>(nullable: false),
                    Accuracy7 = table.Column<double>(nullable: false),
                    Accuracy8 = table.Column<double>(nullable: false),
                    Accuracy9 = table.Column<double>(nullable: false),
                    ContestantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scores_Contestants_ContestantId",
                        column: x => x.ContestantId,
                        principalTable: "Contestants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CurrentRound", "IsFreestyle", "Name", "Poomsae11ID", "Poomsae12ID", "Poomsae21ID", "Poomsae22ID", "Poomsae31ID", "Poomsae32ID", "ShortName" },
                values: new object[,]
                {
                    { 1, null, false, "Kadeti | <=5. geup | do 13 godina", 0, 0, 0, 0, 0, 0, "KA-1" },
                    { 2, null, false, "Kadetkinje | <=5. geup | do 13 godina", 0, 0, 0, 0, 0, 0, "KB-1" },
                    { 3, null, false, "Juniori | <=5. geup | 13 do 17 godina", 0, 0, 0, 0, 0, 0, "JA-1" },
                    { 4, null, false, "Juniorke | <=5. geup | 13 do 17 godina", 0, 0, 0, 0, 0, 0, "JB-1" },
                    { 5, null, false, "Seniori | <=5. geup | 18 do 30 godina", 0, 0, 0, 0, 0, 0, "SA-1" },
                    { 6, null, false, "Seniorke | <=5. geup | 18 do 30 godina", 0, 0, 0, 0, 0, 0, "SB-1" },
                    { 7, null, false, "Veterani | <=5. geup | od 30 godina", 0, 0, 0, 0, 0, 0, "MA-1" },
                    { 8, null, false, "Veteranke | <=5. geup | od 30 godina", 0, 0, 0, 0, 0, 0, "MB-1" },
                    { 9, null, false, "Invalidi M | Kognitivni invaliditet", 0, 0, 0, 0, 0, 0, "PA-1" },
                    { 10, null, false, "Invalidi Ž | Kognitivni invaliditet", 0, 0, 0, 0, 0, 0, "PB-1" },
                    { 11, null, false, "Parovi | <=5. geup", 0, 0, 0, 0, 0, 0, "D-1" },
                    { 12, null, false, "Timovi | <=5. geup", 0, 0, 0, 0, 0, 0, "T-1" },
                    { 13, null, true, "Freestyle M | <=5. geup", 0, 0, 0, 0, 0, 0, "FA-1" },
                    { 14, null, true, "Freestyle Ž | <=5. geup", 0, 0, 0, 0, 0, 0, "FB-1" }
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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Poomsae11ID",
                table: "Categories",
                column: "Poomsae11ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Poomsae12ID",
                table: "Categories",
                column: "Poomsae12ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Poomsae21ID",
                table: "Categories",
                column: "Poomsae21ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Poomsae22ID",
                table: "Categories",
                column: "Poomsae22ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Poomsae31ID",
                table: "Categories",
                column: "Poomsae31ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Poomsae32ID",
                table: "Categories",
                column: "Poomsae32ID");

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_CategoryId",
                table: "Contestants",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_TeamId",
                table: "Contestants",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ContestantId",
                table: "Scores",
                column: "ContestantId");
        }

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
                name: "Scores");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contestants");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Poomsaes");
        }
    }
}
