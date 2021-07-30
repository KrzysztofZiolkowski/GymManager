using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class RefactoredModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedCarnets",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "CarnetCategory",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "CarnetTypeNumber",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "PurchasedAt",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "RemainQty",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "UsedOn",
                table: "PurchasedCarnets");

            migrationBuilder.RenameTable(
                name: "PurchasedCarnets",
                newName: "Carnets");

            migrationBuilder.RenameColumn(
                name: "OwnerEmail",
                table: "Carnets",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "TotalEtrances",
                table: "Carnets",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carnets",
                table: "Carnets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
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
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Carnets_CarnetId",
                        column: x => x.CarnetId,
                        principalTable: "Carnets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    MaxCustomersCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoachExercise",
                columns: table => new
                {
                    CoachesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExercisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachExercise", x => new { x.CoachesId, x.ExercisesId });
                    table.ForeignKey(
                        name: "FK_CoachExercise_AspNetUsers_CoachesId",
                        column: x => x.CoachesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachExercise_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseActivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsExploited = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtrancesLeft = table.Column<int>(type: "int", nullable: true),
                    ActiveUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "CalendarEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacanciesLeft = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: true),
                    CoachId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_AspNetUsers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseRoom",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    RoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRoom", x => new { x.ExercisesId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_ExerciseRoom_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CanBeCanceled = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CalendarEventId = table.Column<int>(type: "int", nullable: true),
                    TimeCarnetActivationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_CalendarEvents_CalendarEventId",
                        column: x => x.CalendarEventId,
                        principalTable: "CalendarEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_PurchaseActivations_TimeCarnetActivationId",
                        column: x => x.TimeCarnetActivationId,
                        principalTable: "PurchaseActivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_CalendarEvents_CoachId",
                table: "CalendarEvents",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_ExerciseId",
                table: "CalendarEvents",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_RoomId",
                table: "CalendarEvents",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachExercise_ExercisesId",
                table: "CoachExercise",
                column: "ExercisesId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRoom_RoomsId",
                table: "ExerciseRoom",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseActivations_PurchaseId",
                table: "PurchaseActivations",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CarnetId",
                table: "Purchases",
                column: "CarnetId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_PurchaseActivationId",
                table: "QuantityCarnetSingleActivations",
                column: "PurchaseActivationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantityCarnetSingleActivations_ReservationId",
                table: "QuantityCarnetSingleActivations",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CalendarEventId",
                table: "Reservations",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeCarnetActivationId",
                table: "Reservations",
                column: "TimeCarnetActivationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoachExercise");

            migrationBuilder.DropTable(
                name: "ExerciseRoom");

            migrationBuilder.DropTable(
                name: "QuantityCarnetSingleActivations");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "PurchaseActivations");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carnets",
                table: "Carnets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Carnets");

            migrationBuilder.DropColumn(
                name: "PeriodInDays",
                table: "Carnets");

            migrationBuilder.DropColumn(
                name: "TotalEtrances",
                table: "Carnets");

            migrationBuilder.RenameTable(
                name: "Carnets",
                newName: "PurchasedCarnets");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "PurchasedCarnets",
                newName: "OwnerEmail");

            migrationBuilder.AddColumn<string>(
                name: "CarnetCategory",
                table: "PurchasedCarnets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarnetTypeNumber",
                table: "PurchasedCarnets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "PurchasedCarnets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PurchasedCarnets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "PurchasedCarnets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PurchasedCarnets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedAt",
                table: "PurchasedCarnets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PurchasedCarnets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainQty",
                table: "PurchasedCarnets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedOn",
                table: "PurchasedCarnets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedCarnets",
                table: "PurchasedCarnets",
                column: "Id");
        }
    }
}
