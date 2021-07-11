using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedTimeCarnetActivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseActivationId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PurchaseActivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsExploited = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseActivations", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseActivations_PurchaseActivationId",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "PurchaseActivations");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseActivationId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseActivationId",
                table: "Purchases");
        }
    }
}
