using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ORMStudy.Migrations
{
    /// <inheritdoc />
    public partial class ProjectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    lastName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    shifr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    project = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    topic = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    dateStart = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.shifr);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    team = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    mentor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                    table.ForeignKey(
                        name: "FK_Team_Mentor_mentor",
                        column: x => x.mentor,
                        principalTable: "Mentor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    lastName = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    team = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Team_team",
                        column: x => x.team,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    takt = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    project_shifr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.id);
                    table.ForeignKey(
                        name: "FK_Work_Project_project_shifr",
                        column: x => x.project_shifr,
                        principalTable: "Project",
                        principalColumn: "shifr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_Students_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Students_team",
                table: "Students",
                column: "team");

            migrationBuilder.CreateIndex(
                name: "IX_Team_mentor",
                table: "Team",
                column: "mentor");

            migrationBuilder.CreateIndex(
                name: "IX_Work_project_shifr",
                table: "Work",
                column: "project_shifr");

            migrationBuilder.CreateIndex(
                name: "IX_Work_student_id",
                table: "Work",
                column: "student_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Mentor");
        }
    }
}
