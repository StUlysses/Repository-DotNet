using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLog",
                columns: table => new
                {
                    LogID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true),
                    SQL = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLog", x => x.LogID);
                });

            migrationBuilder.CreateTable(
                name: "PoemCollection",
                columns: table => new
                {
                    PoemCollectionID = table.Column<Guid>(nullable: false),
                    PoemCollectionName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    PoemCount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoemCollection", x => x.PoemCollectionID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    BgColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Poem",
                columns: table => new
                {
                    PoemID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Auther = table.Column<string>(nullable: true),
                    AutherID = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    WordCount = table.Column<int>(nullable: false),
                    FollowCount = table.Column<int>(nullable: false),
                    PoemCollectionID = table.Column<Guid>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poem", x => x.PoemID);
                    table.ForeignKey(
                        name: "FK_Poem_PoemCollection_PoemCollectionID",
                        column: x => x.PoemCollectionID,
                        principalTable: "PoemCollection",
                        principalColumn: "PoemCollectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoemFollow",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PoemName = table.Column<string>(nullable: false),
                    PoemID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoemFollow", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PoemFollow_Poem_PoemID",
                        column: x => x.PoemID,
                        principalTable: "Poem",
                        principalColumn: "PoemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoemFollow_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFollow",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    PoetID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollow", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFollow_Poem_PoetID",
                        column: x => x.PoetID,
                        principalTable: "Poem",
                        principalColumn: "PoemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollow_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poem_PoemCollectionID",
                table: "Poem",
                column: "PoemCollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_PoemFollow_PoemID",
                table: "PoemFollow",
                column: "PoemID");

            migrationBuilder.CreateIndex(
                name: "IX_PoemFollow_UserID",
                table: "PoemFollow",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollow_PoetID",
                table: "UserFollow",
                column: "PoetID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollow_UserID",
                table: "UserFollow",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLog");

            migrationBuilder.DropTable(
                name: "PoemFollow");

            migrationBuilder.DropTable(
                name: "UserFollow");

            migrationBuilder.DropTable(
                name: "Poem");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PoemCollection");
        }
    }
}
