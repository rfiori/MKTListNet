using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MKTListNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_First_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailEmailList",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "varchar(50)", nullable: false),
                    EmailListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailEmailList", x => new { x.EmailId, x.EmailListId });
                    table.ForeignKey(
                        name: "FK_EmailEmailList_EmailList_EmailListId",
                        column: x => x.EmailListId,
                        principalTable: "EmailList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmailEmailList_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailList",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "General list", "SYS" },
                    { 2, "OptOut", "SYS" },
                    { 3, "Exclusion/Bounce", "SYS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_EmailAddress",
                table: "Email",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_EmailEmailList_EmailListId",
                table: "EmailEmailList",
                column: "EmailListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailEmailList");

            migrationBuilder.DropTable(
                name: "EmailList");

            migrationBuilder.DropTable(
                name: "Email");
        }
    }
}
