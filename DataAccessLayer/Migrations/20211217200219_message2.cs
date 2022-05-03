using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class message2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message2s",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(nullable: true),
                    ReceiverId = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    MessageDetails = table.Column<string>(nullable: true),
                    MessageStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message2s", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_ReceiverId",
                table: "Message2s",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_SenderId",
                table: "Message2s",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message2s");
        }
    }
}
