using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Thesis.Models;

public partial class ScienteficThesisDbContext : DbContext
{
    public ScienteficThesisDbContext()
    {
    }

    public ScienteficThesisDbContext(DbContextOptions<ScienteficThesisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ApplicantAdvisor> ApplicantAdvisors { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<FirstApplication> FirstApplications { get; set; }

    public virtual DbSet<ModifiedApplication> ModifiedApplications { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KBG310N;Database=ScienteficThesisDB;Integrated Security=true;TrustServerCertificate=true; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("PK__Admin__B5B611FB8B93422E");

            entity.ToTable("Admin");

            entity.Property(e => e.AdId).HasColumnName("AD_ID");
            entity.Property(e => e.AdEmail)
                .HasMaxLength(70)
                .HasColumnName("AD_Email");
            entity.Property(e => e.AdName)
                .HasMaxLength(30)
                .HasColumnName("AD_Name");
            entity.Property(e => e.AdPassword)
                .HasMaxLength(70)
                .HasColumnName("AD_Password");
        });

        modelBuilder.Entity<ApplicantAdvisor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ApplicantAdvisor");

            entity.Property(e => e.ApadAdvisorName)
                .HasMaxLength(30)
                .HasColumnName("APAD_AdvisorName");
            entity.Property(e => e.ApadApplicantId).HasColumnName("APAD_ApplicantID");
            entity.Property(e => e.ApadId)
                .ValueGeneratedOnAdd()
                .HasColumnName("APAD_ID");

            entity.HasOne(d => d.ApadApplicant).WithMany()
                .HasForeignKey(d => d.ApadApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkApplicant");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CntId).HasName("PK__Country__378EDE3DF1FB8BBA");

            entity.ToTable("Country");

            entity.Property(e => e.CntId).HasColumnName("CNT_ID");
            entity.Property(e => e.CntNameAr)
                .HasMaxLength(30)
                .HasColumnName("CNT_NameAr");
            entity.Property(e => e.CntNameEn)
                .HasMaxLength(30)
                .HasColumnName("CNT_NameEN");
        });

        modelBuilder.Entity<Degree>(entity =>
        {
            entity.HasKey(e => e.DegId).HasName("PK__Degree__2B30DB893A76D96A");

            entity.ToTable("Degree");

            entity.Property(e => e.DegId).HasColumnName("DEG_ID");
            entity.Property(e => e.DegNameAr)
                .HasMaxLength(15)
                .HasColumnName("DEG_NameAr");
            entity.Property(e => e.DegNameEn)
                .HasMaxLength(15)
                .HasColumnName("DEG_NameEn");
        });

        modelBuilder.Entity<FirstApplication>(entity =>
        {
            entity.HasKey(e => e.AppId).HasName("PK__FirstApp__F00E58047D887401");

            entity.ToTable("FirstApplication");

            entity.Property(e => e.AppId).HasColumnName("APP_ID");
            entity.Property(e => e.AppBirthDate)
                .HasColumnType("date")
                .HasColumnName("APP_BirthDate");
            entity.Property(e => e.AppDegreeId).HasColumnName("APP_DegreeID");
            entity.Property(e => e.AppDepartment)
                .HasMaxLength(50)
                .HasColumnName("APP_Department");
            entity.Property(e => e.AppEmail)
                .HasMaxLength(70)
                .HasColumnName("APP_Email");
            entity.Property(e => e.AppFaculty)
                .HasMaxLength(50)
                .HasColumnName("APP_Faculty");
            entity.Property(e => e.AppJob)
                .HasMaxLength(15)
                .HasColumnName("APP_Job");
            entity.Property(e => e.AppKeyword).HasColumnName("APP_keyword");
            entity.Property(e => e.AppLanguageMaster)
                .HasMaxLength(15)
                .HasColumnName("APP_LanguageMaster");
            entity.Property(e => e.AppNameAr)
                .HasMaxLength(100)
                .HasColumnName("APP_NameAr");
            entity.Property(e => e.AppNameEn)
                .HasMaxLength(100)
                .HasColumnName("APP_NameEn");
            entity.Property(e => e.AppNationalId)
                .HasMaxLength(20)
                .HasColumnName("APP_NationalID");
            entity.Property(e => e.AppNationalityId).HasColumnName("APP_NationalityID");
            entity.Property(e => e.AppNotes).HasColumnName("APP_notes");
            entity.Property(e => e.AppPages).HasColumnName("APP_Pages");
            entity.Property(e => e.AppPublicationYear).HasColumnName("APP_PublicationYear");
            entity.Property(e => e.AppSubmissionLetter)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APP_SubmissionLetter");
            entity.Property(e => e.AppSubmissionTime)
                .HasColumnType("datetime")
                .HasColumnName("APP_SubmissionTime");
            entity.Property(e => e.AppThesis)
                .IsUnicode(false)
                .HasColumnName("APP_Thesis");
            entity.Property(e => e.AppThesisTitleAr)
                .HasMaxLength(80)
                .HasColumnName("APP_ThesisTitleAr");
            entity.Property(e => e.AppThesisTitleEn)
                .HasMaxLength(80)
                .HasColumnName("APP_ThesisTitleEn");
            entity.Property(e => e.AppUniversityId).HasColumnName("APP_UniversityID");
            entity.Property(e => e.AppVolumes).HasColumnName("APP_Volumes");

            entity.HasOne(d => d.AppDegree).WithMany(p => p.FirstApplications)
                .HasForeignKey(d => d.AppDegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkDegree");

            entity.HasOne(d => d.AppNationality).WithMany(p => p.FirstApplications)
                .HasForeignKey(d => d.AppNationalityId)
                .HasConstraintName("FkNationality");

            entity.HasOne(d => d.AppUniversity).WithMany(p => p.FirstApplications)
                .HasForeignKey(d => d.AppUniversityId)
                .HasConstraintName("FkUnversity");
        });

        modelBuilder.Entity<ModifiedApplication>(entity =>
        {
            entity.HasKey(e => e.AppId).HasName("PK__Modified__F00E580498B02BF4");

            entity.ToTable("ModifiedApplication");

            entity.Property(e => e.AppId)
                .ValueGeneratedOnAdd()
                .HasColumnName("APP_ID");
            entity.Property(e => e.AppBirthDate)
                .HasColumnType("date")
                .HasColumnName("APP_BirthDate");
            entity.Property(e => e.AppDegreeId).HasColumnName("APP_DegreeID");
            entity.Property(e => e.AppDepartment)
                .HasMaxLength(50)
                .HasColumnName("APP_Department");
            entity.Property(e => e.AppEbCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("APP_EbCode");
            entity.Property(e => e.AppEmail)
                .HasMaxLength(70)
                .HasColumnName("APP_Email");
            entity.Property(e => e.AppFaculty)
                .HasMaxLength(50)
                .HasColumnName("APP_Faculty");
            entity.Property(e => e.AppJob)
                .HasMaxLength(15)
                .HasColumnName("APP_Job");
            entity.Property(e => e.AppKeyword).HasColumnName("APP_keyword");
            entity.Property(e => e.AppLanguageMaster)
                .HasMaxLength(15)
                .HasColumnName("APP_LanguageMaster");
            entity.Property(e => e.AppLastModificationDate)
                .HasColumnType("datetime")
                .HasColumnName("APP_LastModificationDate");
            entity.Property(e => e.AppLastModifierId).HasColumnName("APP_LastModifierID");
            entity.Property(e => e.AppNameAr)
                .HasMaxLength(100)
                .HasColumnName("APP_NameAr");
            entity.Property(e => e.AppNameEn)
                .HasMaxLength(100)
                .HasColumnName("APP_NameEn");
            entity.Property(e => e.AppNationalId)
                .HasMaxLength(20)
                .HasColumnName("APP_NationalID");
            entity.Property(e => e.AppNationalityId).HasColumnName("APP_NationalityID");
            entity.Property(e => e.AppNotes).HasColumnName("APP_notes");
            entity.Property(e => e.AppPages).HasColumnName("APP_Pages");
            entity.Property(e => e.AppPublicationYear).HasColumnName("APP_PublicationYear");
            entity.Property(e => e.AppStatusId).HasColumnName("APP_StatusID");
            entity.Property(e => e.AppSubmissionLetter)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("APP_SubmissionLetter");
            entity.Property(e => e.AppThesis)
                .IsUnicode(false)
                .HasColumnName("APP_Thesis");
            entity.Property(e => e.AppThesisTitleAr)
                .HasMaxLength(80)
                .HasColumnName("APP_ThesisTitleAr");
            entity.Property(e => e.AppThesisTitleEn)
                .HasMaxLength(80)
                .HasColumnName("APP_ThesisTitleEn");
            entity.Property(e => e.AppUniversityId).HasColumnName("APP_UniversityID");
            entity.Property(e => e.AppVolumes).HasColumnName("APP_Volumes");

            entity.HasOne(d => d.AppDegree).WithMany(p => p.ModifiedApplications)
                .HasForeignKey(d => d.AppDegreeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkDegree1");

            entity.HasOne(d => d.App).WithOne(p => p.ModifiedApplication)
                .HasForeignKey<ModifiedApplication>(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkOriginal");

            entity.HasOne(d => d.AppLastModifier).WithMany(p => p.ModifiedApplications)
                .HasForeignKey(d => d.AppLastModifierId)
                .HasConstraintName("FkAdmin");

            entity.HasOne(d => d.AppNationality).WithMany(p => p.ModifiedApplications)
                .HasForeignKey(d => d.AppNationalityId)
                .HasConstraintName("FkNationality1");

            entity.HasOne(d => d.AppStatus).WithMany(p => p.ModifiedApplications)
                .HasForeignKey(d => d.AppStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkStatus");

            entity.HasOne(d => d.AppUniversity).WithMany(p => p.ModifiedApplications)
                .HasForeignKey(d => d.AppUniversityId)
                .HasConstraintName("FkUnversity1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StId).HasName("PK__Status__EBDB13EF982D8AA8");

            entity.ToTable("Status");

            entity.Property(e => e.StId).HasColumnName("ST_ID");
            entity.Property(e => e.StState)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ST_State");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.HasKey(e => e.UniId).HasName("PK__Universi__4AE960965F46A287");

            entity.ToTable("University");

            entity.Property(e => e.UniId).HasColumnName("UNI_ID");
            entity.Property(e => e.UniNameAr)
                .HasMaxLength(30)
                .HasColumnName("UNI_NameAr");
            entity.Property(e => e.UniNameEn)
                .HasMaxLength(30)
                .HasColumnName("UNI_NameEn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
