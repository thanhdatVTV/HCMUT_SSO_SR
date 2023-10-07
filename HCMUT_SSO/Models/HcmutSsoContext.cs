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

    public virtual DbSet<TblIndustry> TblIndustries { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ADMIN;Database=HCMUT_SSO;Trusted_Connection=true;TrustServerCertificate=True;");

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

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblFaculty>(entity =>
        {
            entity.ToTable("tbl_Faculty");

            entity.Property(e => e.FacultyName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblIndustry>(entity =>
        {
            entity.ToTable("tbl_Industry");

            entity.Property(e => e.IndustryName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.ToTable("tbl_Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.LastName).HasMaxLength(250);
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
