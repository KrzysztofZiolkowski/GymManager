using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedReservationToPurchaseActivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeCarnetActivationId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "QuantityCarnetSingleActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeCarnetReservationId",
                table: "PurchaseActivations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeCarnetActivationId",
                table: "Reservations",
                column: "TimeCarnetActivationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_ReservationId",
                table: "QuantityCarnetSingleActivations",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuantityCarnetSingleActivations_Reservations_ReservationId",
                table: "QuantityCarnetSingleActivations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PurchaseActivations_TimeCarnetActivationId",
                table: "Reservations",
                column: "TimeCarnetActivationId",
                principalTable: "PurchaseActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuantityCarnetSingleActivations_Reservations_ReservationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PurchaseActivations_TimeCarnetActivationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TimeCarnetActivationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_QuantityCarnetSingleActivations_ReservationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropColumn(
                name: "TimeCarnetActivationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "QuantityCarnetSingleActivations");

            migrationBuilder.DropColumn(
                name: "TimeCarnetReservationId",
                table: "PurchaseActivations");
        }
    }
}
