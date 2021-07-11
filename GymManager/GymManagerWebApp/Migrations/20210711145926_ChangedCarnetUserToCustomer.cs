using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class ChangedCarnetUserToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carnet_CarnetId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carnet_AspNetUsers_CustomerId",
                table: "Carnet");

            migrationBuilder.DropIndex(
                name: "IX_Carnet_CustomerId",
                table: "Carnet");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarnetId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Carnet");

            migrationBuilder.DropColumn(
                name: "CarnetId",
                table: "AspNetUsers");

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

            migrationBuilder.CreateIndex(
                name: "IX_CarnetCustomer_CustomersId",
                table: "CarnetCustomer",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarnetCustomer");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Carnet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarnetId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carnet_CustomerId",
                table: "Carnet",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarnetId",
                table: "AspNetUsers",
                column: "CarnetId");

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
        }
    }
}
