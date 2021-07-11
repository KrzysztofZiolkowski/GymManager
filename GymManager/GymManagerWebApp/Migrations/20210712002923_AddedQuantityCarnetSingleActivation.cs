using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedQuantityCarnetSingleActivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuantityCarnetSingleActivations_PurchaseActivations_QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropIndex(
                name: "IX_QuantityCarnetSingleActivations_QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropColumn(
                name: "QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.RenameColumn(
                name: "PurchaseActivationCarnetId",
                table: "PurchaseActivations",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseActivationId",
                table: "QuantityCarnetSingleActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_PurchaseActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "PurchaseActivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuantityCarnetSingleActivations_PurchaseActivations_PurchaseActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "PurchaseActivationId",
                principalTable: "PurchaseActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuantityCarnetSingleActivations_PurchaseActivations_PurchaseActivationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropIndex(
                name: "IX_QuantityCarnetSingleActivations_PurchaseActivationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropColumn(
                name: "PurchaseActivationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PurchaseActivations",
                newName: "PurchaseActivationCarnetId");

            migrationBuilder.AddColumn<int>(
                name: "QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "QuantityCarnetActivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuantityCarnetSingleActivations_PurchaseActivations_QuantityCarnetActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "QuantityCarnetActivationId",
                principalTable: "PurchaseActivations",
                principalColumn: "PurchaseActivationCarnetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
