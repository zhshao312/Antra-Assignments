﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);

            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>("MovieGenre",
                    m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));


            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);

            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users)
                 .UsingEntity<Dictionary<string, object>>("UserRole",
                    u => u.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    r => r.HasOne<User>().WithMany().HasForeignKey("UserId"));

            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            //specify your Fluent rules
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(2048);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2048);

        }
        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Ignore(m => m.Rating);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character});
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.CastId);
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.PurchaseNumber).ValueGeneratedOnAdd();
            builder.HasIndex(p => new { p.UserId, p.MovieId }).IsUnique();
        }
        
        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.MovieId, r.UserId });
            builder.Property(r => r.ReviewText).HasMaxLength(20000);
            builder.Property(r => r.Rating).HasColumnType("decimal(3,2)");
            builder.Property(r => r.CreatedDate).HasDefaultValueSql("getDate()");
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(r => new { r.MovieId, r.UserId });
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(20);
        }
    }
}
