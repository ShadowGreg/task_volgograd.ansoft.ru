using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_volgograd.ansoft.ru.dataAccess.Entities
{
    /// <inheritdoc />
    public partial class Complicatedthemessageandattachmentandmadetheconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Messages",
                type: "BLOB SUB_TYPE TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageType",
                table: "Messages",
                type: "BLOB SUB_TYPE TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Messages",
                type: "BLOB SUB_TYPE TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SendResult",
                table: "Messages",
                type: "BLOB SUB_TYPE TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Messages",
                type: "BLOB SUB_TYPE TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageGuid",
                table: "Attachments",
                type: "VARCHAR(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_MessageGuid",
                table: "Attachments",
                column: "MessageGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Messages_Messag~",
                table: "Attachments",
                column: "MessageGuid",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Messages_Messag~",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_MessageGuid",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageType",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SendResult",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageGuid",
                table: "Attachments");
        }
    }
}
