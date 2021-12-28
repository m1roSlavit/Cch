using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace lab5_api.Models
{
    public partial class APMSSQLMYDBMDFContext : DbContext
    {
        public APMSSQLMYDBMDFContext()
        {
        }

        public APMSSQLMYDBMDFContext(DbContextOptions<APMSSQLMYDBMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Participants> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=First");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participants>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.fullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sex)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
