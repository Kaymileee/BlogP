using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
  /// <inheritdoc />
  public partial class InitialUpdate_v102 : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Attachment_Posts_PostId",
          table: "Attachment");

      migrationBuilder.DropForeignKey(
          name: "FK_PostTag_Tags_TagsTagId",
          table: "PostTag");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Tags",
          table: "Tags");

      migrationBuilder.DropPrimaryKey(
          name: "PK_PostTag",
          table: "PostTag");

      migrationBuilder.DropIndex(
          name: "IX_PostTag_TagsTagId",
          table: "PostTag");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Attachment",
          table: "Attachment");

      migrationBuilder.DropColumn(
          name: "TagId",
          table: "Tags");

      migrationBuilder.DropColumn(
          name: "TagsTagId",
          table: "PostTag");

      migrationBuilder.RenameTable(
          name: "Attachment",
          newName: "Attachments");

      migrationBuilder.RenameIndex(
          name: "IX_Attachment_PostId",
          table: "Attachments",
          newName: "IX_Attachments_PostId");

      migrationBuilder.AddColumn<int>(
          name: "Role",
          table: "Users",
          type: "int",
          nullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "tagId",
          table: "Tags",
          type: "nvarchar(450)",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "nvarchar(max)",
          oldNullable: true);

      migrationBuilder.AddColumn<string>(
          name: "tagId",
          table: "PostTag",
          type: "nvarchar(450)",
          nullable: false,
          defaultValue: "");

      migrationBuilder.AddPrimaryKey(
          name: "PK_Tags",
          table: "Tags",
          column: "tagId");

      migrationBuilder.AddPrimaryKey(
          name: "PK_PostTag",
          table: "PostTag",
          columns: new[] { "PostsPostId", "tagId" });

      migrationBuilder.AddPrimaryKey(
          name: "PK_Attachments",
          table: "Attachments",
          column: "Id");

      migrationBuilder.CreateTable(
          name: "PostTags",
          columns: table => new
          {
            PostId = table.Column<int>(type: "int", nullable: false),
            tagId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            tagId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PostTags", x => new { x.PostId, x.tagId });
            table.ForeignKey(
                      name: "FK_PostTags_Posts_PostId",
                      column: x => x.PostId,
                      principalTable: "Posts",
                      principalColumn: "PostId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_PostTags_Tags_tagId1",
                      column: x => x.tagId1,
                      principalTable: "Tags",
                      principalColumn: "tagId");
          });

      migrationBuilder.CreateIndex(
          name: "IX_PostTag_tagId",
          table: "PostTag",
          column: "tagId");

      migrationBuilder.CreateIndex(
          name: "IX_PostTags_tagId1",
          table: "PostTags",
          column: "tagId1");

      migrationBuilder.AddForeignKey(
          name: "FK_Attachments_Posts_PostId",
          table: "Attachments",
          column: "PostId",
          principalTable: "Posts",
          principalColumn: "PostId",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_PostTag_Tags_tagId",
          table: "PostTag",
          column: "tagId",
          principalTable: "Tags",
          principalColumn: "tagId",
          onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Attachments_Posts_PostId",
          table: "Attachments");

      migrationBuilder.DropForeignKey(
          name: "FK_PostTag_Tags_tagId",
          table: "PostTag");

      migrationBuilder.DropTable(
          name: "PostTags");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Tags",
          table: "Tags");

      migrationBuilder.DropPrimaryKey(
          name: "PK_PostTag",
          table: "PostTag");

      migrationBuilder.DropIndex(
          name: "IX_PostTag_tagId",
          table: "PostTag");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Attachments",
          table: "Attachments");

      migrationBuilder.DropColumn(
          name: "Role",
          table: "Users");

      migrationBuilder.DropColumn(
          name: "tagId",
          table: "PostTag");

      migrationBuilder.RenameTable(
          name: "Attachments",
          newName: "Attachment");

      migrationBuilder.RenameIndex(
          name: "IX_Attachments_PostId",
          table: "Attachment",
          newName: "IX_Attachment_PostId");

      migrationBuilder.AlterColumn<string>(
          name: "tagId",
          table: "Tags",
          type: "nvarchar(max)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(450)");

      migrationBuilder.AddColumn<int>(
          name: "TagId",
          table: "Tags",
          type: "int",
          nullable: false,
          defaultValue: 0)
          .Annotation("SqlServer:Identity", "1, 1");

      migrationBuilder.AddColumn<int>(
          name: "TagsTagId",
          table: "PostTag",
          type: "int",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddPrimaryKey(
          name: "PK_Tags",
          table: "Tags",
          column: "TagId");

      migrationBuilder.AddPrimaryKey(
          name: "PK_PostTag",
          table: "PostTag",
          columns: new[] { "PostsPostId", "TagsTagId" });

      migrationBuilder.AddPrimaryKey(
          name: "PK_Attachment",
          table: "Attachment",
          column: "Id");

      migrationBuilder.CreateIndex(
          name: "IX_PostTag_TagsTagId",
          table: "PostTag",
          column: "TagsTagId");

      migrationBuilder.AddForeignKey(
          name: "FK_Attachment_Posts_PostId",
          table: "Attachment",
          column: "PostId",
          principalTable: "Posts",
          principalColumn: "PostId",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_PostTag_Tags_TagsTagId",
          table: "PostTag",
          column: "TagsTagId",
          principalTable: "Tags",
          principalColumn: "TagId",
          onDelete: ReferentialAction.Cascade);
    }
  }
}
