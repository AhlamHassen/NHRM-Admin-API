using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NHRM_Admin_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasurementName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementID);
                });

            migrationBuilder.CreateTable(
                name: "RecordCategory",
                columns: table => new
                {
                    RecordCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordCategory", x => x.RecordCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    ResourceTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.ResourceTypeID);
                });

            migrationBuilder.CreateTable(
                name: "StaffRole",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCategory", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "DataPoint",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    DataPointNumber = table.Column<int>(type: "int", nullable: false),
                    UpperLimit = table.Column<int>(type: "int", nullable: false),
                    LowerLimit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoint", x => new { x.MeasurementID, x.DataPointNumber });
                    table.ForeignKey(
                        name: "FK_DataPoint_Measurement",
                        column: x => x.MeasurementID,
                        principalTable: "Measurement",
                        principalColumn: "MeasurementID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordType",
                columns: table => new
                {
                    RecordTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecordCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordType", x => x.RecordTypeID);
                    table.ForeignKey(
                        name: "FK_RecordType_RecordCategory",
                        column: x => x.RecordCategoryID,
                        principalTable: "RecordCategory",
                        principalColumn: "RecordCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceID);
                    table.ForeignKey(
                        name: "FK_Resource_ResourceType",
                        column: x => x.TypeID,
                        principalTable: "ResourceType",
                        principalColumn: "ResourceTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(type: "binary(64)", fixedLength: true, maxLength: 64, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_StaffRole",
                        column: x => x.RoleID,
                        principalTable: "StaffRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateMeasurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateMeasurement", x => new { x.MeasurementID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK__TemplateMeasurement_TemplateCategory",
                        column: x => x.CategoryID,
                        principalTable: "TemplateCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateMeasurement_Measurement",
                        column: x => x.MeasurementID,
                        principalTable: "Measurement",
                        principalColumn: "MeasurementID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    DataPointNumber = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => new { x.MeasurementID, x.DataPointNumber });
                    table.ForeignKey(
                        name: "FK_SurveyQuestion_DataPoint",
                        columns: x => new { x.MeasurementID, x.DataPointNumber },
                        principalTable: "DataPoint",
                        principalColumns: new[] { "MeasurementID", "DataPointNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceDialog",
                columns: table => new
                {
                    ResourceDialogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Heading = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceDialog", x => x.ResourceDialogID);
                    table.ForeignKey(
                        name: "FK_ResourceDialog_Resource",
                        column: x => x.ResourceID,
                        principalTable: "Resource",
                        principalColumn: "ResourceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateResource",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateResource", x => new { x.CategoryID, x.ResourceID });
                    table.ForeignKey(
                        name: "FK_TemplateResource_Resource",
                        column: x => x.ResourceID,
                        principalTable: "Resource",
                        principalColumn: "ResourceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateResource_TemplateCategory",
                        column: x => x.CategoryID,
                        principalTable: "TemplateCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HomeNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivesAlone = table.Column<bool>(type: "bit", nullable: false),
                    RegisteredBy = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.URNumber);
                    table.ForeignKey(
                        name: "FK_Patient_Staff",
                        column: x => x.RegisteredBy,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswer",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    DataPointNumber = table.Column<int>(type: "int", nullable: false),
                    AnswerNumber = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswer", x => new { x.MeasurementID, x.DataPointNumber, x.AnswerNumber });
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_SurveyQuestion",
                        columns: x => new { x.MeasurementID, x.DataPointNumber },
                        principalTable: "SurveyQuestion",
                        principalColumns: new[] { "MeasurementID", "DataPointNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCategory", x => new { x.CategoryID, x.URNumber });
                    table.ForeignKey(
                        name: "FK_PatientCategory_Patient",
                        column: x => x.URNumber,
                        principalTable: "Patient",
                        principalColumn: "URNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientCategory_TemplateCategory",
                        column: x => x.CategoryID,
                        principalTable: "TemplateCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientRecord",
                columns: table => new
                {
                    DateTimeRecorded = table.Column<DateTime>(type: "datetime", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecordTypeID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRecord", x => new { x.DateTimeRecorded, x.URNumber, x.RecordTypeID });
                    table.ForeignKey(
                        name: "FK_PatientRecord_Patient",
                        column: x => x.URNumber,
                        principalTable: "Patient",
                        principalColumn: "URNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientRecord_RecordType",
                        column: x => x.RecordTypeID,
                        principalTable: "RecordType",
                        principalColumn: "RecordTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treating",
                columns: table => new
                {
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treating", x => new { x.StartDate, x.URNumber, x.StaffID });
                    table.ForeignKey(
                        name: "FK_Treating_Patient",
                        column: x => x.URNumber,
                        principalTable: "Patient",
                        principalColumn: "URNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treating_Staff",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConditionDetails",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcedureDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NextAppointment = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionDetails", x => new { x.CategoryID, x.URNumber });
                    table.ForeignKey(
                        name: "FK_ConditionDetails_PatientCategory",
                        columns: x => new { x.CategoryID, x.URNumber },
                        principalTable: "PatientCategory",
                        principalColumns: new[] { "CategoryID", "URNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMeasurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    FrequencySetDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMeasurement", x => new { x.MeasurementID, x.CategoryID, x.URNumber });
                    table.ForeignKey(
                        name: "FK_PatientMeasurement_Measurement",
                        column: x => x.MeasurementID,
                        principalTable: "Measurement",
                        principalColumn: "MeasurementID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMeasurement_PatientCategory",
                        columns: x => new { x.CategoryID, x.URNumber },
                        principalTable: "PatientCategory",
                        principalColumns: new[] { "CategoryID", "URNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientResource",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientResource", x => new { x.CategoryID, x.URNumber, x.ResourceID });
                    table.ForeignKey(
                        name: "FK_PatientResource_PatientCategory",
                        columns: x => new { x.CategoryID, x.URNumber },
                        principalTable: "PatientCategory",
                        principalColumns: new[] { "CategoryID", "URNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientResource_Resource",
                        column: x => x.ResourceID,
                        principalTable: "Resource",
                        principalColumn: "ResourceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementRecord",
                columns: table => new
                {
                    MeasurementRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeRecorded = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    URNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementRecord", x => x.MeasurementRecordID);
                    table.ForeignKey(
                        name: "FK_MeasurementRecord_PatientMeasurement",
                        columns: x => new { x.MeasurementID, x.CategoryID, x.URNumber },
                        principalTable: "PatientMeasurement",
                        principalColumns: new[] { "MeasurementID", "CategoryID", "URNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPointRecord",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    DataPointNumber = table.Column<int>(type: "int", nullable: false),
                    MeasurementRecordID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPointRecord", x => new { x.MeasurementID, x.DataPointNumber, x.MeasurementRecordID });
                    table.ForeignKey(
                        name: "FK_DataPointRecord_DataPoint",
                        columns: x => new { x.MeasurementID, x.DataPointNumber },
                        principalTable: "DataPoint",
                        principalColumns: new[] { "MeasurementID", "DataPointNumber" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataPointRecord_MeasurementRecord",
                        column: x => x.MeasurementRecordID,
                        principalTable: "MeasurementRecord",
                        principalColumn: "MeasurementRecordID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPointRecord_MeasurementRecordID",
                table: "DataPointRecord",
                column: "MeasurementRecordID");

            migrationBuilder.CreateIndex(
                name: "UQ_MeasurementName",
                table: "Measurement",
                column: "MeasurementName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementRecord_MeasurementID_CategoryID_URNumber",
                table: "MeasurementRecord",
                columns: new[] { "MeasurementID", "CategoryID", "URNumber" });

            migrationBuilder.CreateIndex(
                name: "UQ_MeasurementRecord",
                table: "MeasurementRecord",
                columns: new[] { "DateTimeRecorded", "MeasurementID", "CategoryID", "URNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_RegisteredBy",
                table: "Patient",
                column: "RegisteredBy");

            migrationBuilder.CreateIndex(
                name: "UQ_Email",
                table: "Patient",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientCategory_URNumber",
                table: "PatientCategory",
                column: "URNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMeasurement_CategoryID_URNumber",
                table: "PatientMeasurement",
                columns: new[] { "CategoryID", "URNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecord_RecordTypeID",
                table: "PatientRecord",
                column: "RecordTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecord_URNumber",
                table: "PatientRecord",
                column: "URNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PatientResource_ResourceID",
                table: "PatientResource",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "UQ_Category",
                table: "RecordCategory",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecordType_RecordCategoryID",
                table: "RecordType",
                column: "RecordCategoryID");

            migrationBuilder.CreateIndex(
                name: "UQ_RecordType",
                table: "RecordType",
                column: "RecordType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resource_TypeID",
                table: "Resource",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceDialog_ResourceID",
                table: "ResourceDialog",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "UQ_ResourceType_TypeName",
                table: "ResourceType",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RoleID",
                table: "Staff",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "UQ_Staff",
                table: "Staff",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_StaffType",
                table: "StaffRole",
                column: "StaffType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_CategoryName",
                table: "TemplateCategory",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateMeasurement_CategoryID",
                table: "TemplateMeasurement",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResource_ResourceID",
                table: "TemplateResource",
                column: "ResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Treating_StaffID",
                table: "Treating",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Treating_URNumber",
                table: "Treating",
                column: "URNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionDetails");

            migrationBuilder.DropTable(
                name: "DataPointRecord");

            migrationBuilder.DropTable(
                name: "PatientRecord");

            migrationBuilder.DropTable(
                name: "PatientResource");

            migrationBuilder.DropTable(
                name: "ResourceDialog");

            migrationBuilder.DropTable(
                name: "SurveyAnswer");

            migrationBuilder.DropTable(
                name: "TemplateMeasurement");

            migrationBuilder.DropTable(
                name: "TemplateResource");

            migrationBuilder.DropTable(
                name: "Treating");

            migrationBuilder.DropTable(
                name: "MeasurementRecord");

            migrationBuilder.DropTable(
                name: "RecordType");

            migrationBuilder.DropTable(
                name: "SurveyQuestion");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "PatientMeasurement");

            migrationBuilder.DropTable(
                name: "RecordCategory");

            migrationBuilder.DropTable(
                name: "DataPoint");

            migrationBuilder.DropTable(
                name: "ResourceType");

            migrationBuilder.DropTable(
                name: "PatientCategory");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "TemplateCategory");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "StaffRole");
        }
    }
}
