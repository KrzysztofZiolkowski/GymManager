using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class RemovedPurchasedCarnets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_PurchasedCarnets_CarnetId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedCarnets",
                table: "PurchasedCarnets");

            migrationBuilder.RenameTable(
                name: "PurchasedCarnets",
                newName: "Carnet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Carnet_CarnetId",
                table: "Purchase",
                column: "CarnetId",
                principalTable: "Carnet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Carnet_CarnetId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet");

            migrationBuilder.RenameTable(
                name: "Carnet",
                newName: "PurchasedCarnets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedCarnets",
                table: "PurchasedCarnets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_PurchasedCarnets_CarnetId",
                table: "Purchase",
                column: "CarnetId",
                principalTable: "PurchasedCarnets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
