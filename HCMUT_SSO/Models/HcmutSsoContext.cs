using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HCMUT_SSO.Models;

public partial class HcmutSsoContext : DbContext
{
    public HcmutSsoContext()
    {
    }

    public HcmutSsoContext(DbContextOptions<HcmutSsoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblClassGroup> TblClassGroups { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblFaculty> TblFaculties { get; set; }

    public virtual DbSet<TblMajor> TblMajors { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblTeacher> TblTeachers { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DAT-NT-0754;Database=HCMUT_SSO;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblClassGroup>(entity =>
        {
            entity.ToTable("tbl_ClassGroup");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassGroupName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.ToTable("tbl_Course");

            entity.Property(e => e.CourseName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblFaculty>(entity =>
        {
            entity.ToTable("tbl_Faculty");

            entity.Property(e => e.FacultyName).HasMaxLength(250);

            entity.HasOne(d => d.Course).WithMany(p => p.TblFaculties)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Faculty_tbl_Course");
        });

        modelBuilder.Entity<TblMajor>(entity =>
        {
            entity.ToTable("tbl_Major");

            entity.Property(e => e.MajorName).HasMaxLength(500);

            entity.HasOne(d => d.Faculty).WithMany(p => p.TblMajors)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Major_tbl_Faculty");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.ToTable("tbl_Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.StudentId).HasMaxLength(50);

            entity.HasOne(d => d.ClassGroup).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.ClassGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Student_tbl_ClassGroup");

            entity.HasOne(d => d.Major).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.MajorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Student_tbl_Major");

            entity.HasOne(d => d.User).WithMany(p => p.TblStudents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Student_tbl_User");
        });

        modelBuilder.Entity<TblTeacher>(entity =>
        {
            entity.ToTable("tbl_Teacher");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.TeacherId).HasMaxLength(50);

            entity.HasOne(d => d.Course).WithMany(p => p.TblTeachers)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Teacher_tbl_Course");

            entity.HasOne(d => d.User).WithMany(p => p.TblTeachers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_Teacher_tbl_User");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("tbl_User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
