﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasedQuantityCarnets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PurchasedAt = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    PurchasedAmount = table.Column<int>(nullable: false),
                    RemainAmount = table.Column<int>(nullable: false),
                    UsedAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedQuantityCarnets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedQuantityCarnets_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedTimeCarnets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PurchasedAt = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    UsedOn = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    IsExpired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedTimeCarnets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedTimeCarnets_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedQuantityCarnets_OwnerId",
                table: "PurchasedQuantityCarnets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedTimeCarnets_OwnerId",
                table: "PurchasedTimeCarnets",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedQuantityCarnets");

            migrationBuilder.DropTable(
                name: "PurchasedTimeCarnets");
        }
    }
}
