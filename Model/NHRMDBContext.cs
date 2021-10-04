using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NHRM_Admin_API.ViewModels;

#nullable disable

namespace NHRM_Admin_API.Model
{
    public partial class NHRMDBContext : DbContext
    {
        public NHRMDBContext()
        {
        }

        public NHRMDBContext(DbContextOptions<NHRMDBContext> options)
            : base(options)
        {
        }

        //all categories in the database
        public DbSet<AllCategoriesView> AllCategoriesView { get; set; }

        //gets all category measurements in db
        public DbSet<CategoryMeasurementsView> CategoryMeasurements { get; set; }

        public virtual DbSet<ConditionDetail> ConditionDetails { get; set; }
        public virtual DbSet<DataPoint> DataPoints { get; set; }
        public virtual DbSet<DataPointRecord> DataPointRecords { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<MeasurementRecord> MeasurementRecords { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientCategory> PatientCategories { get; set; }
        public virtual DbSet<PatientMeasurement> PatientMeasurements { get; set; }
        public virtual DbSet<PatientRecord> PatientRecords { get; set; }
        public virtual DbSet<PatientResource> PatientResources { get; set; }
        public virtual DbSet<RecordCategory> RecordCategories { get; set; }
        public virtual DbSet<RecordType> RecordTypes { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceDialog> ResourceDialogs { get; set; }
        public virtual DbSet<ResourceType> ResourceTypes { get; set; }
        public virtual DbSet<StaffRole> StaffRoles { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<TemplateCategory> TemplateCategories { get; set; }
        public virtual DbSet<TemplateMeasurement> TemplateMeasurements { get; set; }
        public virtual DbSet<TemplateResource> TemplateResources { get; set; }
        public virtual DbSet<Treating> Treatings { get; set; }
        public virtual DbSet<staff> staff { get; set; }
        public DbSet<ViewTableData> ViewTableData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               // optionsBuilder.UseSqlServer("Data Source=nhrmdb.chxrsmr071sd.us-east-1.rds.amazonaws.com;Initial Catalog=NHRMDB;User ID=admin;Password=kereneritrea");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=NH;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //model builder for AllCategoriesView
             modelBuilder.Entity<AllCategoriesView>(entity =>
            {
                entity.HasNoKey();
            });

            //model builder for AllCategoriesView
            modelBuilder.Entity<CategoryMeasurementsView>(entity =>
            {
                entity.HasNoKey();
            });


            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConditionDetail>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.Urnumber });

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.Property(e => e.Diagnosis).HasMaxLength(500);

                entity.Property(e => e.NextAppointment).HasColumnType("datetime");

                entity.Property(e => e.ProcedureDate).HasColumnType("datetime");

                entity.HasOne(d => d.PatientCategory)
                    .WithOne(p => p.ConditionDetail)
                    .HasForeignKey<ConditionDetail>(d => new { d.CategoryId, d.Urnumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConditionDetails_PatientCategory");
            });

            modelBuilder.Entity<DataPoint>(entity =>
            {
                entity.HasKey(e => new { e.MeasurementId, e.DataPointNumber });

                entity.ToTable("DataPoint");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.DataPoints)
                    .HasForeignKey(d => d.MeasurementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataPoint_Measurement");
            });

            modelBuilder.Entity<DataPointRecord>(entity =>
            {
                entity.HasKey(e => new { e.MeasurementId, e.DataPointNumber, e.MeasurementRecordId });

                entity.ToTable("DataPointRecord");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.MeasurementRecordId).HasColumnName("MeasurementRecordID");

                entity.HasOne(d => d.MeasurementRecord)
                    .WithMany(p => p.DataPointRecords)
                    .HasForeignKey(d => d.MeasurementRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataPointRecord_MeasurementRecord");

                entity.HasOne(d => d.DataPoint)
                    .WithMany(p => p.DataPointRecords)
                    .HasForeignKey(d => new { d.MeasurementId, d.DataPointNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DataPointRecord_DataPoint");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.ToTable("Measurement");

                entity.HasIndex(e => e.MeasurementName, "UQ_MeasurementName")
                    .IsUnique();

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.MeasurementName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MeasurementRecord>(entity =>
            {
                entity.ToTable("MeasurementRecord");

                entity.HasIndex(e => new { e.DateTimeRecorded, e.MeasurementId, e.CategoryId, e.Urnumber }, "UQ_MeasurementRecord")
                    .IsUnique();

                entity.Property(e => e.MeasurementRecordId).HasColumnName("MeasurementRecordID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateTimeRecorded).HasColumnType("datetime");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.Urnumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.HasOne(d => d.PatientMeasurement)
                    .WithMany(p => p.MeasurementRecords)
                    .HasForeignKey(d => new { d.MeasurementId, d.CategoryId, d.Urnumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementRecord_PatientMeasurement");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Urnumber);

                entity.ToTable("Patient");

                entity.HasIndex(e => e.Email, "UQ_Email")
                    .IsUnique();

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CountryOfBirth)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HomeNumber).HasMaxLength(10);

                entity.Property(e => e.MobileNumber).HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.PreferredLanguage)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Salt).IsRequired();

                entity.Property(e => e.Suburb)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RegisteredByNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.RegisteredBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Staff");
            });

            modelBuilder.Entity<PatientCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.Urnumber });

                entity.ToTable("PatientCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PatientCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientCategory_TemplateCategory");

                entity.HasOne(d => d.UrnumberNavigation)
                    .WithMany(p => p.PatientCategories)
                    .HasForeignKey(d => d.Urnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientCategory_Patient");
            });

            modelBuilder.Entity<PatientMeasurement>(entity =>
            {
                entity.HasKey(e => new { e.MeasurementId, e.CategoryId, e.Urnumber });

                entity.ToTable("PatientMeasurement");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.Property(e => e.FrequencySetDate).HasColumnType("datetime");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.PatientMeasurements)
                    .HasForeignKey(d => d.MeasurementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMeasurement_Measurement");

                entity.HasOne(d => d.PatientCategory)
                    .WithMany(p => p.PatientMeasurements)
                    .HasForeignKey(d => new { d.CategoryId, d.Urnumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientMeasurement_PatientCategory");
            });

            modelBuilder.Entity<PatientRecord>(entity =>
            {
                entity.HasKey(e => new { e.DateTimeRecorded, e.Urnumber, e.RecordTypeId });

                entity.ToTable("PatientRecord");

                entity.Property(e => e.DateTimeRecorded).HasColumnType("datetime");

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.Property(e => e.RecordTypeId).HasColumnName("RecordTypeID");

                entity.HasOne(d => d.RecordType)
                    .WithMany(p => p.PatientRecords)
                    .HasForeignKey(d => d.RecordTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientRecord_RecordType");

                entity.HasOne(d => d.UrnumberNavigation)
                    .WithMany(p => p.PatientRecords)
                    .HasForeignKey(d => d.Urnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientRecord_Patient");
            });

            modelBuilder.Entity<PatientResource>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.Urnumber, e.ResourceId });

                entity.ToTable("PatientResource");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.PatientResources)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientResource_Resource");

                entity.HasOne(d => d.PatientCategory)
                    .WithMany(p => p.PatientResources)
                    .HasForeignKey(d => new { d.CategoryId, d.Urnumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientResource_PatientCategory");
            });

            modelBuilder.Entity<RecordCategory>(entity =>
            {
                entity.ToTable("RecordCategory");

                entity.HasIndex(e => e.Category, "UQ_Category")
                    .IsUnique();

                entity.Property(e => e.RecordCategoryId).HasColumnName("RecordCategoryID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RecordType>(entity =>
            {
                entity.ToTable("RecordType");

                entity.HasIndex(e => e.RecordType1, "UQ_RecordType")
                    .IsUnique();

                entity.Property(e => e.RecordTypeId).HasColumnName("RecordTypeID");

                entity.Property(e => e.RecordCategoryId).HasColumnName("RecordCategoryID");

                entity.Property(e => e.RecordType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RecordType");

                entity.HasOne(d => d.RecordCategory)
                    .WithMany(p => p.RecordTypes)
                    .HasForeignKey(d => d.RecordCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RecordType_RecordCategory");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Prompt)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_ResourceType");
            });

            modelBuilder.Entity<ResourceDialog>(entity =>
            {
                entity.ToTable("ResourceDialog");

                entity.Property(e => e.ResourceDialogId).HasColumnName("ResourceDialogID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Heading)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceDialogs)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceDialog_Resource");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.ToTable("ResourceType");

                entity.HasIndex(e => e.TypeName, "UQ_ResourceType_TypeName")
                    .IsUnique();

                entity.Property(e => e.ResourceTypeId).HasColumnName("ResourceTypeID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StaffRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("StaffRole");

                entity.HasIndex(e => e.StaffType, "UQ_StaffType")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StaffType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SurveyAnswer>(entity =>
            {
                entity.HasKey(e => new { e.MeasurementId, e.DataPointNumber, e.AnswerNumber });

                entity.ToTable("SurveyAnswer");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.AnswerText).IsRequired();

                entity.HasOne(d => d.SurveyQuestion)
                    .WithMany(p => p.SurveyAnswers)
                    .HasForeignKey(d => new { d.MeasurementId, d.DataPointNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyAnswer_SurveyQuestion");
            });

            modelBuilder.Entity<SurveyQuestion>(entity =>
            {
                entity.HasKey(e => new { e.MeasurementId, e.DataPointNumber });

                entity.ToTable("SurveyQuestion");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.Question).IsRequired();

                entity.HasOne(d => d.DataPoint)
                    .WithOne(p => p.SurveyQuestion)
                    .HasForeignKey<SurveyQuestion>(d => new { d.MeasurementId, d.DataPointNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyQuestion_DataPoint");
            });

            modelBuilder.Entity<TemplateCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("TemplateCategory");

                entity.HasIndex(e => e.CategoryName, "UQ_CategoryName")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TemplateMeasurement>(entity =>
            {
                entity.HasKey(e => new { e.MeasurementId, e.CategoryId });

                entity.ToTable("TemplateMeasurement");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TemplateMeasurements)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TemplateMeasurement_TemplateCategory");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.TemplateMeasurements)
                    .HasForeignKey(d => d.MeasurementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateMeasurement_Measurement");
            });

            modelBuilder.Entity<TemplateResource>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ResourceId });

                entity.ToTable("TemplateResource");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TemplateResources)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateResource_TemplateCategory");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.TemplateResources)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemplateResource_Resource");
            });

            modelBuilder.Entity<Treating>(entity =>
            {
                entity.HasKey(e => new { e.StartDate, e.Urnumber, e.StaffId });

                entity.ToTable("Treating");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Urnumber)
                    .HasMaxLength(50)
                    .HasColumnName("URNumber");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Treatings)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Treating_Staff");

                entity.HasOne(d => d.UrnumberNavigation)
                    .WithMany(p => p.Treatings)
                    .HasForeignKey(d => d.Urnumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Treating_Patient");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.HasIndex(e => e.Email, "UQ_Staff")
                    .IsUnique();

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Salt).IsRequired();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_StaffRole");
            });

            modelBuilder.Entity<ViewTableData>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewTableData");
                entity.Property(v => v.URNumber).HasColumnName("URNumber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
