using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NHRM_Admin_API.Migrations
{
    public partial class ChangingStaffPasword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Staff",
                type: "nchar(64)",
                fixedLength: true,
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(64)",
                oldFixedLength: true,
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Patient",
                type: "varbinary(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.CreateTable(
                name: "AllCategoriesView",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CategoryMeasurements",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    MeasurementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tbl_Alert",
                columns: table => new
                {
                    AlertID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    AlertTypeID = table.Column<int>(type: "int", nullable: false),
                    TriggerValue = table.Column<int>(type: "int", nullable: false),
                    DateTimeRaised = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeActioned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Alert", x => x.AlertID);
                });

            migrationBuilder.CreateTable(
                name: "view_Alerts",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlertTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeRaised = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeActioned = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "view_Log",
                columns: table => new
                {
                    AlertID = table.Column<int>(type: "int", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlertTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    Proceeding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllCategoriesView");

            migrationBuilder.DropTable(
                name: "CategoryMeasurements");

            migrationBuilder.DropTable(
                name: "tbl_Alert");

            migrationBuilder.DropTable(
                name: "view_Alerts");

            migrationBuilder.DropTable(
                name: "view_Log");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Staff",
                type: "binary(64)",
                fixedLength: true,
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(64)",
                oldFixedLength: true,
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Patient",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(400)",
                oldMaxLength: 400);
        }
    }
}
