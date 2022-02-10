using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestTask.Storage.Entities;

#nullable disable

namespace TestTask.Storage
{
    public partial class TestTaskDbContext : DbContext
    {
        public TestTaskDbContext()
        {
        }

        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Name, "UName")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IncidentNameNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IncidentName)
                    .HasConstraintName("FK_Accounts_Incidents");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasIndex(e => e.Email, "UEmail")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Contacts_Accounts");
            });

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
