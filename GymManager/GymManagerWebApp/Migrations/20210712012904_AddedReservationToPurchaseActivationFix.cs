using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedReservationToPurchaseActivationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeCarnetReservationId",
                table: "PurchaseActivations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeCarnetReservationId",
                table: "PurchaseActivations",
                type: "int",
                nullable: true);
        }
    }
}
