using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Railwayweb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingforms",
                columns: table => new
                {
                    PId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phoneno = table.Column<long>(type: "bigint", nullable: false),
                    PName = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Berth = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    CardName = table.Column<string>(type: "text", nullable: false),
                    CMonth = table.Column<int>(type: "integer", nullable: false),
                    CYear = table.Column<int>(type: "integer", nullable: false),
                    Cvno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingforms", x => x.PId);
                });

            migrationBuilder.CreateTable(
                name: "froms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_froms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regisforms",
                columns: table => new
                {
                    Rid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PhoneNo = table.Column<long>(type: "bigint", nullable: false),
                    DoB = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Cpassword = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regisforms", x => x.Rid);
                });

            migrationBuilder.CreateTable(
                name: "tos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FromId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tos_froms_FromId",
                        column: x => x.FromId,
                        principalTable: "froms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loginforms",
                columns: table => new
                {
                    LId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Cpassword = table.Column<string>(type: "text", nullable: false),
                    RegisformRid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginforms", x => x.LId);
                    table.ForeignKey(
                        name: "FK_loginforms_regisforms_RegisformRid",
                        column: x => x.RegisformRid,
                        principalTable: "regisforms",
                        principalColumn: "Rid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainnames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ToId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainnames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainnames_tos_ToId",
                        column: x => x.ToId,
                        principalTable: "tos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_loginforms_RegisformRid",
                table: "loginforms",
                column: "RegisformRid");

            migrationBuilder.CreateIndex(
                name: "IX_tos_FromId",
                table: "tos",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_trainnames_ToId",
                table: "trainnames",
                column: "ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingforms");

            migrationBuilder.DropTable(
                name: "loginforms");

            migrationBuilder.DropTable(
                name: "trainnames");

            migrationBuilder.DropTable(
                name: "regisforms");

            migrationBuilder.DropTable(
                name: "tos");

            migrationBuilder.DropTable(
                name: "froms");
        }
    }
}
