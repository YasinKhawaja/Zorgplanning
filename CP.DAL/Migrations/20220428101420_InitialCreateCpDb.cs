using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP.DAL.Migrations
{
    public partial class InitialCreateCpDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarDates",
                columns: table => new
                {
                    DateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarDates", x => x.DateId);
                });

            migrationBuilder.CreateTable(
                name: "Regimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Start = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    End = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    RegimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Regimes_RegimeId",
                        column: x => x.RegimeId,
                        principalTable: "Regimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsFixedNight = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    RegimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Regimes_RegimeId",
                        column: x => x.RegimeId,
                        principalTable: "Regimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => new { x.EmployeeId, x.DateId });
                    table.ForeignKey(
                        name: "FK_Absences_CalendarDates_DateId",
                        column: x => x.DateId,
                        principalTable: "CalendarDates",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => new { x.EmployeeId, x.ShiftId, x.DateId });
                    table.ForeignKey(
                        name: "FK_Schedules_CalendarDates_DateId",
                        column: x => x.DateId,
                        principalTable: "CalendarDates",
                        principalColumn: "DateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 21, new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 25, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 27, new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 28, new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 29, new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 30, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 31, new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 32, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 33, new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 34, new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 35, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 36, new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 37, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 38, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 39, new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 40, new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 41, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 42, new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 43, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 44, new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 45, new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 46, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 47, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 48, new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 49, new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 50, new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 51, new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 52, new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 53, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 54, new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 55, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 56, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 57, new DateTime(2022, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 58, new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 59, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 60, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 61, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 62, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 63, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 64, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 65, new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 66, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 67, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 68, new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 69, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 70, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 71, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 72, new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 73, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 74, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 75, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 76, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 77, new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 78, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 79, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 80, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 81, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 82, new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 83, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 84, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 85, new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 86, new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 87, new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 88, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 89, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 90, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 91, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 92, new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 93, new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 94, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 95, new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 96, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 97, new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 98, new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 99, new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 100, new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 101, new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 102, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 103, new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 104, new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 105, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 106, new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 107, new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 108, new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 109, new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 110, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 111, new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 112, new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 113, new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 114, new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 115, new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 116, new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 117, new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 118, new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 119, new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 120, new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 121, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 122, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 123, new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 124, new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 125, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 126, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 127, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 128, new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 129, new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 130, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 131, new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 132, new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 133, new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 134, new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 135, new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 136, new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 137, new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 138, new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 139, new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 140, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 141, new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 142, new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 143, new DateTime(2022, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 144, new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 145, new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 146, new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 147, new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 148, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 149, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 150, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 151, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 152, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 153, new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 154, new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 155, new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 156, new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 157, new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 158, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 159, new DateTime(2022, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 160, new DateTime(2022, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 161, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 162, new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 163, new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 164, new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 165, new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 166, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 167, new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 168, new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 169, new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 170, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 171, new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 172, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 173, new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 174, new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 175, new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 176, new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 177, new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 178, new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 179, new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 180, new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 181, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 182, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 183, new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 184, new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 185, new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 186, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 187, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 188, new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 189, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 190, new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 191, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 192, new DateTime(2022, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 193, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 194, new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 195, new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 196, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 197, new DateTime(2022, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 198, new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 199, new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 200, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 201, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 202, new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 203, new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 204, new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 205, new DateTime(2022, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 206, new DateTime(2022, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 207, new DateTime(2022, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 208, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 209, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 210, new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 211, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 212, new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 213, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 214, new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 215, new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 216, new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 217, new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 218, new DateTime(2022, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 219, new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 220, new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 221, new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 222, new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 223, new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 224, new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 225, new DateTime(2022, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 226, new DateTime(2022, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 227, new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 228, new DateTime(2022, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 229, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 230, new DateTime(2022, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 231, new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 232, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 233, new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 234, new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 235, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 236, new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 237, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 238, new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 239, new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 240, new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 241, new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 242, new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 243, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 244, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 245, new DateTime(2022, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 246, new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 247, new DateTime(2022, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 248, new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 249, new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 250, new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 251, new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 252, new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 253, new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 254, new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 255, new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 256, new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 257, new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 258, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 259, new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 260, new DateTime(2022, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 261, new DateTime(2022, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 262, new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 263, new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 264, new DateTime(2022, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 265, new DateTime(2022, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 266, new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 267, new DateTime(2022, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 268, new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 269, new DateTime(2022, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 270, new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 271, new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 272, new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 273, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 274, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 275, new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 276, new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 277, new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 278, new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 279, new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 280, new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 281, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 282, new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 283, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 284, new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 285, new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 286, new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 287, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 288, new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 289, new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 290, new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 291, new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 292, new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 293, new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 294, new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 295, new DateTime(2022, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 296, new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 297, new DateTime(2022, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 298, new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 299, new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 300, new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 301, new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 302, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 303, new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 304, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 305, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 306, new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 307, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 308, new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 309, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 310, new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 311, new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 312, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 313, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 314, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 315, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 316, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 317, new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 318, new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 319, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 320, new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 321, new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 322, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 323, new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 324, new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 325, new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 326, new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 327, new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 328, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 329, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 330, new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 331, new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 332, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 333, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 334, new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 335, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 336, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "CalendarDates",
                columns: new[] { "DateId", "Date", "HolidayName" },
                values: new object[,]
                {
                    { 337, new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 338, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 339, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 340, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 341, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 342, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 343, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 344, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 345, new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 346, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 347, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 348, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 349, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 350, new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 351, new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 352, new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 353, new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 354, new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 355, new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 356, new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 357, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 358, new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 359, new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 360, new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 361, new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 362, new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 363, new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 364, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 365, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Regimes",
                columns: new[] { "Id", "Hours", "Name", "Percentage" },
                values: new object[,]
                {
                    { 1, 38m, "Voltijds", 100 },
                    { 2, 30.4m, "Deeltijds 4/5", 80 },
                    { 3, 28.8m, "Deeltijds 3/4", 75 },
                    { 4, 19m, "Halftijds", 50 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Team A" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "RegimeId", "TeamId" },
                values: new object[,]
                {
                    { 1, "Emp1", "Emp1", 1, 1 },
                    { 2, "Emp2", "Emp2", 1, 1 },
                    { 3, "Emp3", "Emp3", 1, 1 },
                    { 4, "Emp4", "Emp4", 1, 1 },
                    { 5, "Emp5", "Emp5", 2, 1 },
                    { 6, "Emp6", "Emp6", 2, 1 },
                    { 7, "Emp7", "Emp7", 2, 1 },
                    { 8, "Emp8", "Emp8", 3, 1 },
                    { 9, "Emp9", "Emp9", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsFixedNight", "LastName", "RegimeId", "TeamId" },
                values: new object[,]
                {
                    { 10, "Emp10", true, "Emp10", 1, 1 },
                    { 11, "Emp11", true, "Emp11", 1, 1 },
                    { 12, "Emp12", true, "Emp12", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "End", "Name", "RegimeId", "Start" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 15, 0, 0, 0), "Vroeg", 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 2, new TimeSpan(0, 13, 30, 0, 0), "Vroeg", 2, new TimeSpan(0, 7, 0, 0, 0) },
                    { 3, new TimeSpan(0, 13, 30, 0, 0), "Vroeg", 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { 4, new TimeSpan(0, 11, 0, 0, 0), "Vroeg", 4, new TimeSpan(0, 7, 0, 0, 0) },
                    { 5, new TimeSpan(0, 20, 30, 0, 0), "Laat", 1, new TimeSpan(0, 12, 30, 0, 0) },
                    { 6, new TimeSpan(0, 20, 30, 0, 0), "Laat", 2, new TimeSpan(0, 14, 0, 0, 0) },
                    { 7, new TimeSpan(0, 20, 30, 0, 0), "Laat", 3, new TimeSpan(0, 14, 0, 0, 0) },
                    { 8, new TimeSpan(0, 20, 0, 0, 0), "Laat", 4, new TimeSpan(0, 16, 0, 0, 0) },
                    { 9, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 1, new TimeSpan(0, 20, 15, 0, 0) },
                    { 10, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 2, new TimeSpan(0, 20, 15, 0, 0) },
                    { 11, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 3, new TimeSpan(0, 20, 15, 0, 0) },
                    { 12, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 4, new TimeSpan(0, 20, 15, 0, 0) },
                    { 13, new TimeSpan(0, 0, 0, 0, 0), "Geen", 1, new TimeSpan(0, 0, 0, 0, 0) },
                    { 14, new TimeSpan(0, 0, 0, 0, 0), "Geen", 2, new TimeSpan(0, 0, 0, 0, 0) },
                    { 15, new TimeSpan(0, 0, 0, 0, 0), "Geen", 3, new TimeSpan(0, 0, 0, 0, 0) },
                    { 16, new TimeSpan(0, 0, 0, 0, 0), "Geen", 4, new TimeSpan(0, 0, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_DateId",
                table: "Absences",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RegimeId",
                table: "Employees",
                column: "RegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Regimes_Name",
                table: "Regimes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DateId",
                table: "Schedules",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ShiftId",
                table: "Schedules",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_RegimeId",
                table: "Shifts",
                column: "RegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "CalendarDates");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Regimes");
        }
    }
}
