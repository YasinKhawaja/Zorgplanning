﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CP.DAL.Migrations
{
    public partial class InitialCreateCarePlannerDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    DateId = table.Column<DateTime>(type: "date", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.DateId);
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
                    DateId = table.Column<DateTime>(type: "date", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => new { x.EmployeeId, x.DateId });
                    table.ForeignKey(
                        name: "FK_Absences_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
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
                    DateId = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => new { x.EmployeeId, x.ShiftId, x.DateId });
                    table.ForeignKey(
                        name: "FK_Schedules_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
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
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Dates",
                column: "DateId",
                values: new object[]
                {
                    new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
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
                    { 1, new TimeSpan(0, 15, 0, 0, 0), "Vroege", 1, new TimeSpan(0, 7, 0, 0, 0) },
                    { 2, new TimeSpan(0, 13, 30, 0, 0), "Vroege", 2, new TimeSpan(0, 7, 0, 0, 0) },
                    { 3, new TimeSpan(0, 13, 30, 0, 0), "Vroege", 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { 4, new TimeSpan(0, 11, 0, 0, 0), "Vroege", 4, new TimeSpan(0, 7, 0, 0, 0) },
                    { 5, new TimeSpan(0, 20, 30, 0, 0), "Late", 1, new TimeSpan(0, 12, 30, 0, 0) },
                    { 6, new TimeSpan(0, 20, 30, 0, 0), "Late", 2, new TimeSpan(0, 14, 0, 0, 0) },
                    { 7, new TimeSpan(0, 20, 30, 0, 0), "Late", 3, new TimeSpan(0, 14, 0, 0, 0) },
                    { 8, new TimeSpan(0, 20, 0, 0, 0), "Late", 4, new TimeSpan(0, 16, 0, 0, 0) },
                    { 9, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 1, new TimeSpan(0, 20, 15, 0, 0) },
                    { 10, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 2, new TimeSpan(0, 20, 15, 0, 0) },
                    { 11, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 3, new TimeSpan(0, 20, 15, 0, 0) },
                    { 12, new TimeSpan(0, 7, 15, 0, 0), "Nacht", 4, new TimeSpan(0, 20, 15, 0, 0) }
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
                name: "Dates");

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
