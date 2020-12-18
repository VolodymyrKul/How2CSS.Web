using How2CSS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.DAL
{
    public class How2CSSDbContext : DbContext
    {
        public How2CSSDbContext()
        {
        }

        public How2CSSDbContext(DbContextOptions<How2CSSDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAchievement> UserAchievements { get; set; }
        public virtual DbSet<AchievementData> AchievementDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUser");

                entity.Property(e => e.Id)
                .HasColumnName("Id_User");

                entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            modelBuilder.Entity<UserAchievement>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUserAchievement");

                entity.Property(e => e.Id)
                .HasColumnName("Id_UserAchievement");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.HasOne(ua => ua.IdUserNavigation)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(ua => ua.IdUser)
                .HasConstraintName("R_1");
            });

            modelBuilder.Entity<AchievementData>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKAchievementData");

                entity.Property(e => e.Id)
                .HasColumnName("Id_AchievementData");

                entity.HasOne(ad => ad.IdUserAchievementNavigation)
                .WithMany(ua => ua.AchievementDatas)
                .HasForeignKey(ad => ad.IdUserAchievement)
                .HasConstraintName("R_2");
            });
        }
    }
}
