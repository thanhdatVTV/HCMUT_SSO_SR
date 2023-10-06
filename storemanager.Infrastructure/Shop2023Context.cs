using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using storemanager.Entity.Entities;

#nullable disable

namespace storemanager.Infrastructure
{
    public partial class Shop2023Context : DbContext
    {
        public Shop2023Context()
        {
        }

        public Shop2023Context(DbContextOptions<Shop2023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblcustomer> Tblcustomers { get; set; }
        public virtual DbSet<Tblcustomerdetail> Tblcustomerdetails { get; set; }
        public virtual DbSet<Tblproduct> Tblproducts { get; set; }
        public virtual DbSet<Tblshop> Tblshops { get; set; }
        public virtual DbSet<Tblshopdetail> Tblshopdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=Shop2023;user id=sa;password=1;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Tblcustomer>(entity =>
            {
                entity.ToTable("tblcustomers");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tblcustomerdetail>(entity =>
            {
                entity.ToTable("tblcustomerdetails");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Tblproduct>(entity =>
            {
                entity.ToTable("tblproducts");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tblshop>(entity =>
            {
                entity.ToTable("tblshops");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Tblshopdetail>(entity =>
            {
                entity.ToTable("tblshopdetails");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
