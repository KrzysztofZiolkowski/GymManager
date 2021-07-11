using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedQuantityCarnetActivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseActivations_PurchaseActivationId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseActivationId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseActivationId",
                table: "Purchases");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PurchaseActivations",
                newName: "PurchaseActivationCarnetId");

            migrationBuilder.AddColumn<int>(
                name: "EtrancesLeft",
                table: "PurchaseActivations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "PurchaseActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuantityCarnetSingleActivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityCarnetActivationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityCarnetSingleActivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuantityCarnetSingleActivations_PurchaseActivations_QuantityCarnetActivationId",
                        column: x => x.QuantityCarnetActivationId,
                        principalTable: "PurchaseActivations",
                        principalColumn: "PurchaseActivationCarnetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseActivations_PurchaseId",
                table: "PurchaseActivations",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "QuantityCarnetActivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseActivations_Purchases_PurchaseId",
                table: "PurchaseActivations",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseActivations_Purchases_PurchaseId",
                table: "PurchaseActivations");

            migrationBuilder.DropTable(
                name: "QuantityCarnetSingleActivations");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseActivations_PurchaseId",
                table: "PurchaseActivations");

            migrationBuilder.DropColumn(
                name: "EtrancesLeft",
                table: "PurchaseActivations");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "PurchaseActivations");

            migrationBuilder.RenameColumn(
                name: "PurchaseActivationCarnetId",
                table: "PurchaseActivations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseActivationId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseActivationId",
                table: "Purchases",
                column: "PurchaseActivationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseActivations_PurchaseActivationId",
                table: "Purchases",
                column: "PurchaseActivationId",
                principalTable: "PurchaseActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
