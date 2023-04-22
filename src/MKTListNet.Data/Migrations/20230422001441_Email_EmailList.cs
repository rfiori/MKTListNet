using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MKTListNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class EmailEmailList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "EmailList",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailList", x => x.ListId);
                });

            migrationBuilder.InsertData(
                table: "EmailList",
                columns: new[] { "ListId", "ListName" },
                values: new object[,]
                {
                    { 1, "Geral list" },
                    { 2, "OptOut" },
                    { 3, "Exclusion/Bounce" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_EmailAddress",
                table: "Email",
                column: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "EmailList");
        }
    }
}
