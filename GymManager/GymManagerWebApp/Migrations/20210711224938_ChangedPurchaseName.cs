using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class ChangedPurchaseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_AspNetUsers_CustomerId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Carnet_CarnetId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchases",
                newName: "IX_Purchases_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_CarnetId",
                table: "Purchases",
                newName: "IX_Purchases_CarnetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AspNetUsers_CustomerId",
                table: "Purchases",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Carnet_CarnetId",
                table: "Purchases",
                column: "CarnetId",
                principalTable: "Carnet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AspNetUsers_CustomerId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Carnet_CarnetId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchase",
                newName: "IX_Purchase_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_CarnetId",
                table: "Purchase",
                newName: "IX_Purchase_CarnetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_AspNetUsers_CustomerId",
                table: "Purchase",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Carnet_CarnetId",
                table: "Purchase",
                column: "CarnetId",
                principalTable: "Carnet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
