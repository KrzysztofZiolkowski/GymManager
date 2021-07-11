using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class NewCarnetStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuantityCarnets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etrances = table.Column<int>(type: "int", nullable: false),
                    RemainEtrances = table.Column<int>(type: "int", nullable: false),
                    ActivationDates = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Activated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityCarnets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeCarnets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Activated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCarnets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuantityCarnetUser",
                columns: table => new
                {
                    QuantityCarnetsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityCarnetUser", x => new { x.QuantityCarnetsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_QuantityCarnetUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantityCarnetUser_QuantityCarnets_QuantityCarnetsId",
                        column: x => x.QuantityCarnetsId,
                        principalTable: "QuantityCarnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeCarnetUser",
                columns: table => new
                {
                    TimeCarnetsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCarnetUser", x => new { x.TimeCarnetsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TimeCarnetUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeCarnetUser_TimeCarnets_TimeCarnetsId",
                        column: x => x.TimeCarnetsId,
                        principalTable: "TimeCarnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetUser_UsersId",
                table: "QuantityCarnetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeCarnetUser_UsersId",
                table: "TimeCarnetUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityCarnetUser");

            migrationBuilder.DropTable(
                name: "TimeCarnetUser");

            migrationBuilder.DropTable(
                name: "QuantityCarnets");

            migrationBuilder.DropTable(
                name: "TimeCarnets");
        }
    }
}
