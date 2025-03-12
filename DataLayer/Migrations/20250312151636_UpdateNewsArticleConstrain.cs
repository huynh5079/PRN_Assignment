using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewsArticleConstrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ParentCategoryID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__19093A2B149E0E87", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK__Category__Parent__286302EC",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "SystemAccount",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AccountRole = table.Column<int>(type: "int", nullable: false),
                    AccountPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SystemAc__349DA586ACB0FB8E", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tag__657CFA4CA50096A8", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "NewsArticle",
                columns: table => new
                {
                    NewsArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NewsContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsSource = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    NewsStatus = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedByID = table.Column<int>(type: "int", nullable: false),
                    UpdatedByID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NewsArti__4CD0926C1819EB3F", x => x.NewsArticleID);
                    table.ForeignKey(
                        name: "FK__NewsArtic__Categ__300424B4",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__NewsArtic__Creat__30F848ED",
                        column: x => x.CreatedByID,
                        principalTable: "SystemAccount",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__NewsArtic__Updat__31EC6D26",
                        column: x => x.UpdatedByID,
                        principalTable: "SystemAccount",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsTag",
                columns: table => new
                {
                    NewsArticleID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NewsTag__9A875DC84F6FA309", x => new { x.NewsArticleID, x.TagID });
                    table.ForeignKey(
                        name: "FK__NewsTag__NewsArt__34C8D9D1",
                        column: x => x.NewsArticleID,
                        principalTable: "NewsArticle",
                        principalColumn: "NewsArticleID");
                    table.ForeignKey(
                        name: "FK__NewsTag__TagID__35BCFE0A",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticle_CategoryID",
                table: "NewsArticle",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticle_CreatedByID",
                table: "NewsArticle",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticle_UpdatedByID",
                table: "NewsArticle",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTag_TagID",
                table: "NewsTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "UQ__SystemAc__FC770D33DA9D6807",
                table: "SystemAccount",
                column: "AccountEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Tag__BDE0FD1D03F93995",
                table: "Tag",
                column: "TagName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsTag");

            migrationBuilder.DropTable(
                name: "NewsArticle");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SystemAccount");
        }
    }
}
