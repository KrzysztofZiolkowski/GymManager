using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class RemovedTimeCarnets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Carnets_CarnetId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PurchaseActivations_TimeCarnetActivationId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "QuantityCarnetSingleActivations");

            migrationBuilder.DropTable(
                name: "PurchaseActivations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carnets",
                table: "Carnets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Carnets");

            migrationBuilder.DropColumn(
                name: "PeriodInDays",
                table: "Carnets");

            migrationBuilder.RenameTable(
                name: "Carnets",
                newName: "Carnet");

            migrationBuilder.RenameColumn(
                name: "TimeCarnetActivationId",
                table: "Reservations",
                newName: "PurchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TimeCarnetActivationId",
                table: "Reservations",
                newName: "IX_Reservations_PurchaseId");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Purchases",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Purchases",
                newName: "ActivationDeadline");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Carnet",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Purchases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RemainCarnets",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WasActivated",
                table: "Purchases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TotalEtrances",
                table: "Carnet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarnetActivation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarnetId = table.Column<int>(type: "int", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarnetActivation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarnetActivation_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarnetActivation_Carnet_CarnetId",
                        column: x => x.CarnetId,
                        principalTable: "Carnet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarnetActivation_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarnetActivation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarnetActivation_CarnetId",
                table: "CarnetActivation",
                column: "CarnetId");

            migrationBuilder.CreateIndex(
                name: "IX_CarnetActivation_CustomerId",
                table: "CarnetActivation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarnetActivation_PurchaseId",
                table: "CarnetActivation",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CarnetActivation_ReservationId",
                table: "CarnetActivation",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Carnet_CarnetId",
                table: "Purchases",
                column: "CarnetId",
                principalTable: "Carnet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Purchases_PurchaseId",
                table: "Reservations",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Carnet_CarnetId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Purchases_PurchaseId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "CarnetActivation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "RemainCarnets",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "WasActivated",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Carnet",
                newName: "Carnets");

            migrationBuilder.RenameColumn(
                name: "PurchaseId",
                table: "Reservations",
                newName: "TimeCarnetActivationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PurchaseId",
                table: "Reservations",
                newName: "IX_Reservations_TimeCarnetActivationId");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Purchases",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "ActivationDeadline",
                table: "Purchases",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Carnets",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<int>(
                name: "TotalEtrances",
                table: "Carnets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Carnets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PeriodInDays",
                table: "Carnets",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carnets",
                table: "Carnets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PurchaseActivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsExploited = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    EtrancesLeft = table.Column<int>(type: "int", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveUntil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseActivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseActivations_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuantityCarnetSingleActivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseActivationId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityCarnetSingleActivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantityCarnetSingleActivations_PurchaseActivations_PurchaseActivationId",
                        column: x => x.PurchaseActivationId,
                        principalTable: "PurchaseActivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantityCarnetSingleActivations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseActivations_PurchaseId",
                table: "PurchaseActivations",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_PurchaseActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "PurchaseActivationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_ReservationId",
                table: "QuantityCarnetSingleActivations",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Carnets_CarnetId",
                table: "Purchases",
                column: "CarnetId",
                principalTable: "Carnets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PurchaseActivations_TimeCarnetActivationId",
                table: "Reservations",
                column: "TimeCarnetActivationId",
                principalTable: "PurchaseActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
