﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: false),
                    FlightRateId = table.Column<Guid>(nullable: false),
                    NoOfSeats = table.Column<int>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    OrderedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    ConfirmedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_FlightRates_FlightRateId",
                        column: x => x.FlightRateId,
                        principalTable: "FlightRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightId",
                table: "Orders",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightRateId",
                table: "Orders",
                column: "FlightRateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
