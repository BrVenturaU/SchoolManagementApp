using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<byte>(type: "tinyint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<short>(type: "smallint", nullable: false),
                    GradeId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Primer Grado. Mayormente asisten niños de 7 años.", true, "1°" },
                    { (byte)2, "Segundo Grado. Mayormente asisten niños de 8 años.", true, "2°" },
                    { (byte)3, "Tercer Grado. Mayormente asisten niños de 9 años.", true, "3°" },
                    { (byte)4, "Cuarto Grado. Mayormente asisten niños de 10 años.", true, "4°" },
                    { (byte)5, "Quinto Grado. Mayormente asisten niños de 11 años.", true, "5°" },
                    { (byte)6, "Sexto Grado. Mayormente asisten niños de 12 años.", true, "6°" },
                    { (byte)7, "Séptimo Grado. Mayormente asisten adolescentes de 13 años.", true, "7°" },
                    { (byte)8, "Octavo Grado. Mayormente asisten adolescentes de 14 años.", true, "8°" },
                    { (byte)9, "Sexto Grado. Mayormente asisten adolescentes de 15 años.", true, "9°" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GradeId",
                table: "Enrollments",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Oid",
                table: "Enrollments",
                column: "Oid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TeacherId",
                table: "Enrollments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Oid",
                table: "Grades",
                column: "Oid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Oid",
                table: "Students",
                column: "Oid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Oid",
                table: "Teachers",
                column: "Oid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
