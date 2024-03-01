using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_volgograd.ansoft.ru.dataAccess.Migration
{
    /// <inheritdoc />
    public partial class Initial : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Email = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    MessageType = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Subject = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Content = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    SendResult = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    AttachmentFile = table.Column<byte[]>(type: "BLOB SUB_TYPE BINARY", nullable: true),
                    MessageId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Messages_Messag~",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_MessageId",
                table: "Attachments",
                column: "MessageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
