using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKTListNet.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddNtoNEmail_EmailList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailEmailList",
                columns: table => new
                {
                    EmailId = table.Column<Guid>(type: "TEXT", nullable: false),
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
        }
    }
}
