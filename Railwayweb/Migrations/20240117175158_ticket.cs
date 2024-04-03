using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Railwayweb.Migrations
{
    public partial class ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingLists");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "bookingforms");

            migrationBuilder.AlterColumn<string>(
                name: "CardName",
                table: "bookingforms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "bookingforms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "bookingforms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BName",
                table: "bookingforms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Berth",
                table: "bookingforms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "bookingforms",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "bookingforms");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "bookingforms");

            migrationBuilder.DropColumn(
                name: "BName",
                table: "bookingforms");

            migrationBuilder.DropColumn(
                name: "Berth",
                table: "bookingforms");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "bookingforms");

            migrationBuilder.AlterColumn<string>(
                name: "CardName",
                table: "bookingforms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "bookingforms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "bookingLists",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingDetailsId = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingLists", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookingLists_bookingforms_BookingDetailsId",
                        column: x => x.BookingDetailsId,
                        principalTable: "bookingforms",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingLists_BookingDetailsId",
                table: "bookingLists",
                column: "BookingDetailsId");
        }
    }
}
