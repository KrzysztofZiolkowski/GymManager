using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class NewModelsStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityCarnetUser");

            migrationBuilder.DropTable(
                name: "TimeCarnetUser");

            migrationBuilder.DropTable(
                name: "QuantityCarnets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeCarnets",
                table: "TimeCarnets");

            migrationBuilder.RenameTable(
                name: "TimeCarnets",
                newName: "Carnet");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarnetId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActiveUntil",
                table: "Carnet",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Carnet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Carnet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RemainEtrances",
                table: "Carnet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalEtrances",
                table: "Carnet",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuantityCarnetActivationDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityCarnetId = table.Column<int>(type: "int", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityCarnetActivationDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantityCarnetActivationDate_Carnet_QuantityCarnetId",
                        column: x => x.QuantityCarnetId,
                        principalTable: "Carnet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarnetId",
                table: "AspNetUsers",
                column: "CarnetId");

            migrationBuilder.CreateIndex(
                name: "IX_Carnet_CustomerId",
                table: "Carnet",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetActivationDate_QuantityCarnetId",
                table: "QuantityCarnetActivationDate",
                column: "QuantityCarnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carnet_CarnetId",
                table: "AspNetUsers",
                column: "CarnetId",
                principalTable: "Carnet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carnet_AspNetUsers_CustomerId",
                table: "Carnet",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carnet_CarnetId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carnet_AspNetUsers_CustomerId",
                table: "Carnet");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "QuantityCarnetActivationDate");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarnetId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet");

            migrationBuilder.DropIndex(
                name: "IX_Carnet_CustomerId",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CarnetId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "RemainEtrances",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "TotalEtrances",
                table: "Carnet");

            migrationBuilder.RenameTable(
                name: "Carnet",
                newName: "TimeCarnets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActiveUntil",
                table: "TimeCarnets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeCarnets",
                table: "TimeCarnets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuantityCarnets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activated = table.Column<bool>(type: "bit", nullable: false),
                    ActivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivationDates = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etrances = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainEtrances = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityCarnets", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetUser_UsersId",
                table: "QuantityCarnetUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeCarnetUser_UsersId",
                table: "TimeCarnetUser",
                column: "UsersId");
        }
    }
}
