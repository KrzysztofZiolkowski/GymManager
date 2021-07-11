using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class RefactoredCarnets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "CarnetCustomer");

            migrationBuilder.DropTable(
                name: "QuantityCarnetActivationDate");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Activated",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "ActivatedOn",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "ActiveUntil",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "PurchasedAt",
                table: "Carnet");

            migrationBuilder.RenameTable(
                name: "Carnet",
                newName: "PurchasedCarnets");

            migrationBuilder.RenameColumn(
                name: "RemainEtrances",
                table: "PurchasedCarnets",
                newName: "PeriodInDays");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PurchasedCarnets",
                newName: "Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedCarnets",
                table: "PurchasedCarnets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarnetId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_PurchasedCarnets_CarnetId",
                        column: x => x.CarnetId,
                        principalTable: "PurchasedCarnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CarnetId",
                table: "Purchase",
                column: "CarnetId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedCarnets",
                table: "PurchasedCarnets");

            migrationBuilder.RenameTable(
                name: "PurchasedCarnets",
                newName: "Carnet");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Carnet",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PeriodInDays",
                table: "Carnet",
                newName: "RemainEtrances");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "Carnet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivatedOn",
                table: "Carnet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveUntil",
                table: "Carnet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Carnet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Carnet",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedAt",
                table: "Carnet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carnet",
                table: "Carnet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarnetCustomer",
                columns: table => new
                {
                    CarnetsId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarnetCustomer", x => new { x.CarnetsId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_CarnetCustomer_AspNetUsers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarnetCustomer_Carnet_CarnetsId",
                        column: x => x.CarnetsId,
                        principalTable: "Carnet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuantityCarnetActivationDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityCarnetId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarnetCustomer_CustomersId",
                table: "CarnetCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetActivationDate_QuantityCarnetId",
                table: "QuantityCarnetActivationDate",
                column: "QuantityCarnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
