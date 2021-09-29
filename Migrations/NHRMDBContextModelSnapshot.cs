﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NHRM_Admin_API.Model;

namespace NHRM_Admin_API.Migrations
{
    [DbContext(typeof(NHRMDBContext))]
    partial class NHRMDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NHRM_Admin_API.Model.ConditionDetail", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.Property<string>("Diagnosis")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("NextAppointment")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ProcedureDate")
                        .HasColumnType("datetime");

                    b.HasKey("CategoryId", "Urnumber");

                    b.ToTable("ConditionDetails");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.DataPoint", b =>
                {
                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<int>("DataPointNumber")
                        .HasColumnType("int");

                    b.Property<int>("LowerLimit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UpperLimit")
                        .HasColumnType("int");

                    b.HasKey("MeasurementId", "DataPointNumber");

                    b.ToTable("DataPoint");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.DataPointRecord", b =>
                {
                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<int>("DataPointNumber")
                        .HasColumnType("int");

                    b.Property<int>("MeasurementRecordId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementRecordID");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("MeasurementId", "DataPointNumber", "MeasurementRecordId");

                    b.HasIndex("MeasurementRecordId");

                    b.ToTable("DataPointRecord");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("MeasurementName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MeasurementId");

                    b.HasIndex(new[] { "MeasurementName" }, "UQ_MeasurementName")
                        .IsUnique();

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.MeasurementRecord", b =>
                {
                    b.Property<int>("MeasurementRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MeasurementRecordID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<DateTime>("DateTimeRecorded")
                        .HasColumnType("datetime");

                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<string>("Urnumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.HasKey("MeasurementRecordId");

                    b.HasIndex("MeasurementId", "CategoryId", "Urnumber");

                    b.HasIndex(new[] { "DateTimeRecorded", "MeasurementId", "CategoryId", "Urnumber" }, "UQ_MeasurementRecord")
                        .IsUnique();

                    b.ToTable("MeasurementRecord");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Patient", b =>
                {
                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfBirth")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HomeNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("LivesAlone")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("PreferredLanguage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegisteredBy")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Urnumber");

                    b.HasIndex("RegisteredBy");

                    b.HasIndex(new[] { "Email" }, "UQ_Email")
                        .IsUnique();

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.HasKey("CategoryId", "Urnumber");

                    b.HasIndex("Urnumber");

                    b.ToTable("PatientCategory");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientMeasurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<DateTime>("FrequencySetDate")
                        .HasColumnType("datetime");

                    b.HasKey("MeasurementId", "CategoryId", "Urnumber");

                    b.HasIndex("CategoryId", "Urnumber");

                    b.ToTable("PatientMeasurement");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientRecord", b =>
                {
                    b.Property<DateTime>("DateTimeRecorded")
                        .HasColumnType("datetime");

                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.Property<int>("RecordTypeId")
                        .HasColumnType("int")
                        .HasColumnName("RecordTypeID");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DateTimeRecorded", "Urnumber", "RecordTypeId");

                    b.HasIndex("RecordTypeId");

                    b.HasIndex("Urnumber");

                    b.ToTable("PatientRecord");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientResource", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int")
                        .HasColumnName("ResourceID");

                    b.HasKey("CategoryId", "Urnumber", "ResourceId");

                    b.HasIndex("ResourceId");

                    b.ToTable("PatientResource");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.RecordCategory", b =>
                {
                    b.Property<int>("RecordCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RecordCategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RecordCategoryId");

                    b.HasIndex(new[] { "Category" }, "UQ_Category")
                        .IsUnique();

                    b.ToTable("RecordCategory");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.RecordType", b =>
                {
                    b.Property<int>("RecordTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RecordTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecordCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("RecordCategoryID");

                    b.Property<string>("RecordType1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RecordType");

                    b.HasKey("RecordTypeId");

                    b.HasIndex("RecordCategoryId");

                    b.HasIndex(new[] { "RecordType1" }, "UQ_RecordType")
                        .IsUnique();

                    b.ToTable("RecordType");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResourceID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("nvarchar(65)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.HasKey("ResourceId");

                    b.HasIndex("TypeId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.ResourceDialog", b =>
                {
                    b.Property<int>("ResourceDialogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResourceDialogID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int")
                        .HasColumnName("ResourceID");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceDialogId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceDialog");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.ResourceType", b =>
                {
                    b.Property<int>("ResourceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResourceTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ResourceTypeId");

                    b.HasIndex(new[] { "TypeName" }, "UQ_ResourceType_TypeName")
                        .IsUnique();

                    b.ToTable("ResourceType");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.StaffRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StaffType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.HasIndex(new[] { "StaffType" }, "UQ_StaffType")
                        .IsUnique();

                    b.ToTable("StaffRole");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.SurveyAnswer", b =>
                {
                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<int>("DataPointNumber")
                        .HasColumnType("int");

                    b.Property<int>("AnswerNumber")
                        .HasColumnType("int");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("MeasurementId", "DataPointNumber", "AnswerNumber");

                    b.ToTable("SurveyAnswer");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.SurveyQuestion", b =>
                {
                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<int>("DataPointNumber")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeasurementId", "DataPointNumber");

                    b.ToTable("SurveyQuestion");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.TemplateCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.HasIndex(new[] { "CategoryName" }, "UQ_CategoryName")
                        .IsUnique();

                    b.ToTable("TemplateCategory");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.TemplateMeasurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("MeasurementID");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.HasKey("MeasurementId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TemplateMeasurement");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.TemplateResource", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int")
                        .HasColumnName("ResourceID");

                    b.HasKey("CategoryId", "ResourceId");

                    b.HasIndex("ResourceId");

                    b.ToTable("TemplateResource");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Treating", b =>
                {
                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Urnumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("URNumber");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("StaffID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.HasKey("StartDate", "Urnumber", "StaffId");

                    b.HasIndex("StaffId");

                    b.HasIndex("Urnumber");

                    b.ToTable("Treating");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StaffID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("binary(64)")
                        .IsFixedLength(true);

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StaffId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Email" }, "UQ_Staff")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.ConditionDetail", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.PatientCategory", "PatientCategory")
                        .WithOne("ConditionDetail")
                        .HasForeignKey("NHRM_Admin_API.Model.ConditionDetail", "CategoryId", "Urnumber")
                        .HasConstraintName("FK_ConditionDetails_PatientCategory")
                        .IsRequired();

                    b.Navigation("PatientCategory");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.DataPoint", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.Measurement", "Measurement")
                        .WithMany("DataPoints")
                        .HasForeignKey("MeasurementId")
                        .HasConstraintName("FK_DataPoint_Measurement")
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.DataPointRecord", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.MeasurementRecord", "MeasurementRecord")
                        .WithMany("DataPointRecords")
                        .HasForeignKey("MeasurementRecordId")
                        .HasConstraintName("FK_DataPointRecord_MeasurementRecord")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.DataPoint", "DataPoint")
                        .WithMany("DataPointRecords")
                        .HasForeignKey("MeasurementId", "DataPointNumber")
                        .HasConstraintName("FK_DataPointRecord_DataPoint")
                        .IsRequired();

                    b.Navigation("DataPoint");

                    b.Navigation("MeasurementRecord");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.MeasurementRecord", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.PatientMeasurement", "PatientMeasurement")
                        .WithMany("MeasurementRecords")
                        .HasForeignKey("MeasurementId", "CategoryId", "Urnumber")
                        .HasConstraintName("FK_MeasurementRecord_PatientMeasurement")
                        .IsRequired();

                    b.Navigation("PatientMeasurement");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Patient", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.staff", "RegisteredByNavigation")
                        .WithMany("Patients")
                        .HasForeignKey("RegisteredBy")
                        .HasConstraintName("FK_Patient_Staff")
                        .IsRequired();

                    b.Navigation("RegisteredByNavigation");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientCategory", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.TemplateCategory", "Category")
                        .WithMany("PatientCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_PatientCategory_TemplateCategory")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.Patient", "UrnumberNavigation")
                        .WithMany("PatientCategories")
                        .HasForeignKey("Urnumber")
                        .HasConstraintName("FK_PatientCategory_Patient")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("UrnumberNavigation");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientMeasurement", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.Measurement", "Measurement")
                        .WithMany("PatientMeasurements")
                        .HasForeignKey("MeasurementId")
                        .HasConstraintName("FK_PatientMeasurement_Measurement")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.PatientCategory", "PatientCategory")
                        .WithMany("PatientMeasurements")
                        .HasForeignKey("CategoryId", "Urnumber")
                        .HasConstraintName("FK_PatientMeasurement_PatientCategory")
                        .IsRequired();

                    b.Navigation("Measurement");

                    b.Navigation("PatientCategory");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientRecord", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.RecordType", "RecordType")
                        .WithMany("PatientRecords")
                        .HasForeignKey("RecordTypeId")
                        .HasConstraintName("FK_PatientRecord_RecordType")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.Patient", "UrnumberNavigation")
                        .WithMany("PatientRecords")
                        .HasForeignKey("Urnumber")
                        .HasConstraintName("FK_PatientRecord_Patient")
                        .IsRequired();

                    b.Navigation("RecordType");

                    b.Navigation("UrnumberNavigation");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientResource", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.Resource", "Resource")
                        .WithMany("PatientResources")
                        .HasForeignKey("ResourceId")
                        .HasConstraintName("FK_PatientResource_Resource")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.PatientCategory", "PatientCategory")
                        .WithMany("PatientResources")
                        .HasForeignKey("CategoryId", "Urnumber")
                        .HasConstraintName("FK_PatientResource_PatientCategory")
                        .IsRequired();

                    b.Navigation("PatientCategory");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.RecordType", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.RecordCategory", "RecordCategory")
                        .WithMany("RecordTypes")
                        .HasForeignKey("RecordCategoryId")
                        .HasConstraintName("FK_RecordType_RecordCategory")
                        .IsRequired();

                    b.Navigation("RecordCategory");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Resource", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.ResourceType", "Type")
                        .WithMany("Resources")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Resource_ResourceType")
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.ResourceDialog", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.Resource", "Resource")
                        .WithMany("ResourceDialogs")
                        .HasForeignKey("ResourceId")
                        .HasConstraintName("FK_ResourceDialog_Resource")
                        .IsRequired();

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.SurveyAnswer", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.SurveyQuestion", "SurveyQuestion")
                        .WithMany("SurveyAnswers")
                        .HasForeignKey("MeasurementId", "DataPointNumber")
                        .HasConstraintName("FK_SurveyAnswer_SurveyQuestion")
                        .IsRequired();

                    b.Navigation("SurveyQuestion");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.SurveyQuestion", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.DataPoint", "DataPoint")
                        .WithOne("SurveyQuestion")
                        .HasForeignKey("NHRM_Admin_API.Model.SurveyQuestion", "MeasurementId", "DataPointNumber")
                        .HasConstraintName("FK_SurveyQuestion_DataPoint")
                        .IsRequired();

                    b.Navigation("DataPoint");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.TemplateMeasurement", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.TemplateCategory", "Category")
                        .WithMany("TemplateMeasurements")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__TemplateMeasurement_TemplateCategory")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.Measurement", "Measurement")
                        .WithMany("TemplateMeasurements")
                        .HasForeignKey("MeasurementId")
                        .HasConstraintName("FK_TemplateMeasurement_Measurement")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.TemplateResource", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.TemplateCategory", "Category")
                        .WithMany("TemplateResources")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_TemplateResource_TemplateCategory")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.Resource", "Resource")
                        .WithMany("TemplateResources")
                        .HasForeignKey("ResourceId")
                        .HasConstraintName("FK_TemplateResource_Resource")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Treating", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.staff", "Staff")
                        .WithMany("Treatings")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK_Treating_Staff")
                        .IsRequired();

                    b.HasOne("NHRM_Admin_API.Model.Patient", "UrnumberNavigation")
                        .WithMany("Treatings")
                        .HasForeignKey("Urnumber")
                        .HasConstraintName("FK_Treating_Patient")
                        .IsRequired();

                    b.Navigation("Staff");

                    b.Navigation("UrnumberNavigation");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.staff", b =>
                {
                    b.HasOne("NHRM_Admin_API.Model.StaffRole", "Role")
                        .WithMany("staff")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Staff_StaffRole")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.DataPoint", b =>
                {
                    b.Navigation("DataPointRecords");

                    b.Navigation("SurveyQuestion");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Measurement", b =>
                {
                    b.Navigation("DataPoints");

                    b.Navigation("PatientMeasurements");

                    b.Navigation("TemplateMeasurements");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.MeasurementRecord", b =>
                {
                    b.Navigation("DataPointRecords");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Patient", b =>
                {
                    b.Navigation("PatientCategories");

                    b.Navigation("PatientRecords");

                    b.Navigation("Treatings");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientCategory", b =>
                {
                    b.Navigation("ConditionDetail");

                    b.Navigation("PatientMeasurements");

                    b.Navigation("PatientResources");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.PatientMeasurement", b =>
                {
                    b.Navigation("MeasurementRecords");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.RecordCategory", b =>
                {
                    b.Navigation("RecordTypes");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.RecordType", b =>
                {
                    b.Navigation("PatientRecords");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.Resource", b =>
                {
                    b.Navigation("PatientResources");

                    b.Navigation("ResourceDialogs");

                    b.Navigation("TemplateResources");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.ResourceType", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.StaffRole", b =>
                {
                    b.Navigation("staff");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.SurveyQuestion", b =>
                {
                    b.Navigation("SurveyAnswers");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.TemplateCategory", b =>
                {
                    b.Navigation("PatientCategories");

                    b.Navigation("TemplateMeasurements");

                    b.Navigation("TemplateResources");
                });

            modelBuilder.Entity("NHRM_Admin_API.Model.staff", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("Treatings");
                });
#pragma warning restore 612, 618
        }
    }
}
