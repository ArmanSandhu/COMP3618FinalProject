using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMDbDomain.Models
{
    public partial class IMDbContext : DbContext
    {
        public IMDbContext()
        {
        }

        public IMDbContext(DbContextOptions<IMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Titlebasics> Titlebasics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=IMDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Titlebasics>(entity =>
            {
                entity.HasKey(e => e.Tconst)
                    .HasName("PK_titlebasics_tconst");

                entity.ToTable("titlebasics", "movie");

                entity.Property(e => e.Tconst)
                    .HasColumnName("tconst")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EndYear).HasColumnName("endYear");

                entity.Property(e => e.Genres)
                    .HasColumnName("genres")
                    .HasMaxLength(50);

                entity.Property(e => e.IsAdult).HasColumnName("isAdult");

                entity.Property(e => e.OriginalTitle)
                    .HasColumnName("originalTitle")
                    .HasMaxLength(1000);

                entity.Property(e => e.PrimaryTitle)
                    .HasColumnName("primaryTitle")
                    .HasMaxLength(1000);

                entity.Property(e => e.RuntimeMinutes).HasColumnName("runtimeMinutes");

                entity.Property(e => e.StartYear).HasColumnName("startYear");

                entity.Property(e => e.TitleType)
                    .HasColumnName("titleType")
                    .HasMaxLength(20);
            });
        }
    }
}
