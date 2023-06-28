using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Data.Migrations
{
  /// <inheritdoc />
  public partial class Initial : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Categories",
          columns: table => new
          {
            CategoryId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Categories", x => x.CategoryId);
          });

      migrationBuilder.CreateTable(
          name: "Tags",
          columns: table => new
          {
            TagId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            TagId = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Tags", x => x.TagId);
          });

      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: true),
            Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.UserId);
          });

      migrationBuilder.CreateTable(
          name: "Posts",
          columns: table => new
          {
            PostId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            ListTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Status = table.Column<int>(type: "int", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Posts", x => x.PostId);
            table.ForeignKey(
                      name: "FK_Posts_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "UserId");
          });

      migrationBuilder.CreateTable(
          name: "Attachment",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            FileType = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
            FileSize = table.Column<long>(type: "bigint", nullable: false),
            CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            PostId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Attachment", x => x.Id);
            table.ForeignKey(
                      name: "FK_Attachment_Posts_PostId",
                      column: x => x.PostId,
                      principalTable: "Posts",
                      principalColumn: "PostId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "CategoryPost",
          columns: table => new
          {
            CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
            PostsPostId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_CategoryPost", x => new { x.CategoriesCategoryId, x.PostsPostId });
            table.ForeignKey(
                      name: "FK_CategoryPost_Categories_CategoriesCategoryId",
                      column: x => x.CategoriesCategoryId,
                      principalTable: "Categories",
                      principalColumn: "CategoryId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_CategoryPost_Posts_PostsPostId",
                      column: x => x.PostsPostId,
                      principalTable: "Posts",
                      principalColumn: "PostId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Comments",
          columns: table => new
          {
            CommentId = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
            ReplyId = table.Column<int>(type: "int", nullable: false),
            PostId = table.Column<int>(type: "int", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Comments", x => x.CommentId);
            table.ForeignKey(
                      name: "FK_Comments_Posts_PostId",
                      column: x => x.PostId,
                      principalTable: "Posts",
                      principalColumn: "PostId");
          });

      migrationBuilder.CreateTable(
          name: "PostCategories",
          columns: table => new
          {
            PostId = table.Column<int>(type: "int", nullable: false),
            CategoryId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
            table.ForeignKey(
                      name: "FK_PostCategories_Categories_CategoryId",
                      column: x => x.CategoryId,
                      principalTable: "Categories",
                      principalColumn: "CategoryId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_PostCategories_Posts_PostId",
                      column: x => x.PostId,
                      principalTable: "Posts",
                      principalColumn: "PostId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "PostTag",
          columns: table => new
          {
            PostsPostId = table.Column<int>(type: "int", nullable: false),
            TagsTagId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PostTag", x => new { x.PostsPostId, x.TagsTagId });
            table.ForeignKey(
                      name: "FK_PostTag_Posts_PostsPostId",
                      column: x => x.PostsPostId,
                      principalTable: "Posts",
                      principalColumn: "PostId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_PostTag_Tags_TagsTagId",
                      column: x => x.TagsTagId,
                      principalTable: "Tags",
                      principalColumn: "TagId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Attachment_PostId",
          table: "Attachment",
          column: "PostId");

      migrationBuilder.CreateIndex(
          name: "IX_CategoryPost_PostsPostId",
          table: "CategoryPost",
          column: "PostsPostId");

      migrationBuilder.CreateIndex(
          name: "IX_Comments_PostId",
          table: "Comments",
          column: "PostId");

      migrationBuilder.CreateIndex(
          name: "IX_PostCategories_CategoryId",
          table: "PostCategories",
          column: "CategoryId");

      migrationBuilder.CreateIndex(
          name: "IX_Posts_UserId",
          table: "Posts",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_PostTag_TagsTagId",
          table: "PostTag",
          column: "TagsTagId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Attachment");

      migrationBuilder.DropTable(
          name: "CategoryPost");

      migrationBuilder.DropTable(
          name: "Comments");

      migrationBuilder.DropTable(
          name: "PostCategories");

      migrationBuilder.DropTable(
          name: "PostTag");

      migrationBuilder.DropTable(
          name: "Categories");

      migrationBuilder.DropTable(
          name: "Posts");

      migrationBuilder.DropTable(
          name: "Tags");

      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}
