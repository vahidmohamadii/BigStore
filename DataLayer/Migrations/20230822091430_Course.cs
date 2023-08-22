using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseLevels",
                columns: table => new
                {
                    CourselevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseLevels", x => x.CourselevelId);
                });

            migrationBuilder.CreateTable(
                name: "courseStatuses",
                columns: table => new
                {
                    CourseStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseStatuses", x => x.CourseStatusId);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseGroupId = table.Column<int>(nullable: false),
                    CourseSubGroupId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseStatusId = table.Column<int>(nullable: false),
                    CourseLevelId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(maxLength: 100, nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    DemoFileName = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    CourseId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_courses_groups_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalTable: "groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_courses_CourseId1",
                        column: x => x.CourseId1,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courses_courseLevels_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "courseLevels",
                        principalColumn: "CourselevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_courseStatuses_CourseStatusId",
                        column: x => x.CourseStatusId,
                        principalTable: "courseStatuses",
                        principalColumn: "CourseStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_groups_CourseSubGroupId",
                        column: x => x.CourseSubGroupId,
                        principalTable: "groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courses_users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    EpiodeTime = table.Column<DateTime>(maxLength: 100, nullable: false),
                    EpisodeFileName = table.Column<string>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_episodes_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseGroupId",
                table: "courses",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseId1",
                table: "courses",
                column: "CourseId1");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseLevelId",
                table: "courses",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseStatusId",
                table: "courses",
                column: "CourseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseSubGroupId",
                table: "courses",
                column: "CourseSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_TeacherId",
                table: "courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_episodes_CourseId",
                table: "episodes",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "episodes");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "courseLevels");

            migrationBuilder.DropTable(
                name: "courseStatuses");
        }
    }
}
