using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    public partial class CreateBookedSeatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_User_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Payments_PaymentId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Tickets_TicketId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_User_UserId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Salons_SalonId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketFiles_Tickets_TicketId",
                table: "TicketFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_CategoryId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Salons_SalonId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CategoryId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SalonId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_TicketFiles_TicketId",
                table: "TicketFiles");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SalonId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PaymentId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_TicketId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.CreateTable(
                name: "BookedSeats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeatId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TicketId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false,defaultValue: DateTime.UtcNow)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedSeats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
