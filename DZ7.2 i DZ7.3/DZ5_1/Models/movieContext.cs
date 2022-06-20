using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AA_2.Models
{
    public partial class movieContext : DbContext
    {
        public movieContext()
        {
        }

        public movieContext(DbContextOptions<movieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCast> MovieCast { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<ProductionCompany> ProductionCompany { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=birt;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.movie_id)
                    .HasName("PK_movie_movie_id");

                entity.ToTable("movie", "movies");

                entity.Property(e => e.movie_id)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_id");

                entity.Property(e => e.title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.budget)
                    .HasMaxLength(50)
                    .HasColumnName("budget");

                entity.Property(e => e.homepage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("homepage");

                entity.Property(e => e.overview)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("overview");

                entity.Property(e => e.popularity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("popularity");

                entity.Property(e => e.release_date)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("release_date");

                entity.Property(e => e.runtime)
                 .IsRequired()
                 .HasMaxLength(50)
                 .HasColumnName("runtime");

                entity.Property(e => e.movie_status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("movie_status");

                entity.Property(e => e.tagline)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tagline");

                entity.Property(e => e.vote_average)
                    .HasMaxLength(15)
                    .HasColumnName("vote_average");


                entity.Property(e => e.vote_count)
                    .HasMaxLength(50)
                    .HasColumnName("vote_count");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasKey(e => e.movie_id)
                    .HasName("PK_movie_cast_movie_id");

                entity.ToTable("movie_cast", "movies");

                entity.Property(e => e.movie_id)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_id");

                entity.Property(e => e.person_id)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("person_id");

                entity.Property(e => e.character_name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("character_name");

                entity.Property(e => e.gender_id)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("gender_id");

                entity.Property(e => e.cast_order)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cast_order");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.department_id)
                    .HasName("PK_department_department_id");

                entity.ToTable("department", "movies");

                entity.Property(e => e.department_id)
                    .HasMaxLength(50)
                    .HasColumnName("department_id");

                entity.Property(e => e.department_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.person_id);

                entity.ToTable("person", "movies");

                entity.Property(e => e.person_id)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.Property(e => e.person_name)
                    .HasPrecision(0)
                    .HasColumnName("person_name");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => new { e.genre_id })
                    .HasName("PK_genre_genre_id");

                entity.ToTable("genre", "movies");

                entity.Property(e => e.genre_id)
                    .HasMaxLength(50)
                    .HasColumnName("genre_id");

                entity.Property(e => e.genre_name).HasColumnName("genre_name");
  
            });

            modelBuilder.Entity<MovieCompany>(entity =>
            {
                entity.HasKey(e => new { e.movie_id, e.company_id })
                    .HasName("PK_movie_company_company_id");

                entity.ToTable("movie_company", "movies");


                entity.Property(e => e.movie_id)
                    .HasMaxLength(50)
                    .HasColumnName("movie_id");

                entity.Property(e => e.company_id)
                    .HasPrecision(0)
                    .HasColumnName("company_id");
            });

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.HasKey(e => e.company_id)
                    .HasName("PK_production_company_company_id");

                entity.ToTable("production_company", "movie");

                entity.Property(e => e.company_id)
                    .HasMaxLength(50)
                    .HasColumnName("company_id");

                entity.Property(e => e.company_name)
                    .IsRequired()
                    .HasColumnName("company_name");

            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.country_id);

                entity.ToTable("country", "movies");

                entity.Property(e => e.country_id)
                    .ValueGeneratedNever()
                    .HasColumnName("country_id");

                entity.Property(e => e.country_iso_code)
                    .HasPrecision(0)
                    .HasColumnName("person_name");
                entity.Property(e => e.country_name)
                   .HasPrecision(0)
                   .HasColumnName("country_name");

            });
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
