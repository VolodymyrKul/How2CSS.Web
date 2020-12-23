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
        public virtual DbSet<Level> Levels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=how2css.db");
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

                entity.HasData(
                    new User {
                        Id = 1,
                        FirstName = "Oksana",
                        LastName = "Iliv",
                        Email = "ilivocs@gmail.com",
                        Password = "_Aa123456",
                        Phone = "0123456789",
                        Role = "User"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Mykhailo",
                        LastName = "Turianskyi",
                        Email = "turyanmykh@gmail.com",
                        Password = "_Aa123456",
                        Phone = "1234567890",
                        Role = "User"
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Oleksandr",
                        LastName = "Stasenko",
                        Email = "stasenoleks@gmail.com",
                        Password = "_Aa123456",
                        Phone = "2345678901",
                        Role = "User"
                    },
                    new User
                    {
                        Id = 4,
                        FirstName = "Yurii",
                        LastName = "Pynzyn",
                        Email = "pynzynyura@gmail.com",
                        Password = "_Aa123456",
                        Phone = "3456789012",
                        Role = "User"
                    },
                    new User
                    {
                        Id = 5,
                        FirstName = "Andrii",
                        LastName = "Hlado",
                        Email = "hladyoandr@gmail.com",
                        Password = "_Aa123456",
                        Phone = "4567890123",
                        Role = "User"
                    });
            });

            modelBuilder.Entity<Level>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKLevel");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Level");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasData(
                    new Level {
                        Id = 1,
                        Title = "CSS_Part1",
                        TasksCount = 30
                    },
                    new Level
                    {
                        Id = 2,
                        Title = "CSS_Part2",
                        TasksCount = 30
                    },
                    new Level
                    {
                        Id = 3,
                        Title = "CSS_Part3",
                        TasksCount = 30
                    },
                    new Level
                    {
                        Id = 4,
                        Title = "CSS_Part4",
                        TasksCount = 30
                    },
                    new Level
                    {
                        Id = 5,
                        Title = "CSS_Part5",
                        TasksCount = 30
                    });
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

                entity.HasOne(ua => ua.IdLevelNavigation)
                .WithMany(l => l.UserAchievements)
                .HasForeignKey(ua => ua.IdLevel)
                .HasConstraintName("R_3");

                entity.HasData(
                    new UserAchievement {
                        Id=1,
                        Title = "Task1 Achivement",
                        Notes = "Need to learn margin",
                        IdLevel = 1,
                        IdUser = 1,
                        SaveDate = new DateTime(2020,12,19)
                    },
                    new UserAchievement
                    {
                        Id = 2,
                        Title = "Task2 Achivement",
                        Notes = "Need to learn padding",
                        IdLevel = 2,
                        IdUser = 1,
                        SaveDate = new DateTime(2020, 12, 21)
                    },
                    new UserAchievement
                    {
                        Id = 3,
                        Title = "Task3 Achivement",
                        Notes = "Need to learn border",
                        IdLevel = 3,
                        IdUser = 1,
                        SaveDate = new DateTime(2020, 12, 23)
                    },
                    new UserAchievement
                    {
                        Id = 4,
                        Title = "Task4 Achivement",
                        Notes = "Need to learn links",
                        IdLevel = 4,
                        IdUser = 1,
                        SaveDate = new DateTime(2020, 12, 25)
                    },
                    new UserAchievement
                    {
                        Id = 5,
                        Title = "Task5 Achivement",
                        Notes = "Need to learn tables",
                        IdLevel = 5,
                        IdUser = 1,
                        SaveDate = new DateTime(2020, 12, 27)
                    },
                    new UserAchievement
                    {
                        Id = 6,
                        Title = "Task1 Achivement",
                        Notes = "Need to learn position",
                        IdLevel = 1,
                        IdUser = 2,
                        SaveDate = new DateTime(2020, 12, 29)
                    },
                    new UserAchievement
                    {
                        Id = 7,
                        Title = "Task2 Achivement",
                        Notes = "Need to learn float",
                        IdLevel = 2,
                        IdUser = 2,
                        SaveDate = new DateTime(2020, 12, 31)
                    },
                    new UserAchievement
                    {
                        Id = 8,
                        Title = "Task3 Achivement",
                        Notes = "Need to learn align",
                        IdLevel = 3,
                        IdUser = 2,
                        SaveDate = new DateTime(2020, 12, 20)
                    },
                    new UserAchievement
                    {
                        Id = 9,
                        Title = "Task4 Achivement",
                        Notes = "Need to learn opacity",
                        IdLevel = 4,
                        IdUser = 2,
                        SaveDate = new DateTime(2020, 12, 22)
                    },
                    new UserAchievement
                    {
                        Id = 10,
                        Title = "Task5 Achivement",
                        Notes = "Need to learn forms",
                        IdLevel = 5,
                        IdUser = 2,
                        SaveDate = new DateTime(2020, 12, 24)
                    });
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

                entity.HasData(
                    new AchievementData {
                        Id=1,
                        CompletedCount = 15,
                        CorrectCount = 12,
                        CurrentMark = 24,
                        TryCount = 1,
                        IdUserAchievement = 1
                    },
                    new AchievementData
                    {
                        Id = 2,
                        CompletedCount = 18,
                        CorrectCount = 15,
                        CurrentMark = 30,
                        TryCount = 2,
                        IdUserAchievement = 1
                    },
                    new AchievementData
                    {
                        Id = 3,
                        CompletedCount = 21,
                        CorrectCount = 18,
                        CurrentMark = 36,
                        TryCount = 3,
                        IdUserAchievement = 1
                    },
                    new AchievementData
                    {
                        Id = 4,
                        CompletedCount = 17,
                        CorrectCount = 14,
                        CurrentMark = 28,
                        TryCount = 1,
                        IdUserAchievement = 2
                    },
                    new AchievementData
                    {
                        Id = 5,
                        CompletedCount = 20,
                        CorrectCount = 17,
                        CurrentMark = 34,
                        TryCount = 2,
                        IdUserAchievement = 2
                    },
                    new AchievementData
                    {
                        Id = 6,
                        CompletedCount = 23,
                        CorrectCount = 20,
                        CurrentMark = 40,
                        TryCount = 3,
                        IdUserAchievement = 2
                    },
                    new AchievementData
                    {
                        Id = 7,
                        CompletedCount = 19,
                        CorrectCount = 16,
                        CurrentMark = 32,
                        TryCount = 1,
                        IdUserAchievement = 3
                    },
                    new AchievementData
                    {
                        Id = 8,
                        CompletedCount = 22,
                        CorrectCount = 19,
                        CurrentMark = 38,
                        TryCount = 2,
                        IdUserAchievement = 3
                    },
                    new AchievementData
                    {
                        Id = 9,
                        CompletedCount = 25,
                        CorrectCount = 22,
                        CurrentMark = 44,
                        TryCount = 3,
                        IdUserAchievement = 3
                    },
                    new AchievementData
                    {
                        Id = 10,
                        CompletedCount = 21,
                        CorrectCount = 18,
                        CurrentMark = 36,
                        TryCount = 1,
                        IdUserAchievement = 4
                    },
                    new AchievementData
                    {
                        Id = 11,
                        CompletedCount = 24,
                        CorrectCount = 21,
                        CurrentMark = 42,
                        TryCount = 2,
                        IdUserAchievement = 4
                    },
                    new AchievementData
                    {
                        Id = 12,
                        CompletedCount = 27,
                        CorrectCount = 24,
                        CurrentMark = 48,
                        TryCount = 3,
                        IdUserAchievement = 4
                    },
                    new AchievementData
                    {
                        Id = 13,
                        CompletedCount = 23,
                        CorrectCount = 20,
                        CurrentMark = 40,
                        TryCount = 1,
                        IdUserAchievement = 5
                    },
                    new AchievementData
                    {
                        Id = 14,
                        CompletedCount = 26,
                        CorrectCount = 23,
                        CurrentMark = 46,
                        TryCount = 2,
                        IdUserAchievement = 5
                    },
                    new AchievementData
                    {
                        Id = 15,
                        CompletedCount = 29,
                        CorrectCount = 26,
                        CurrentMark = 52,
                        TryCount = 3,
                        IdUserAchievement = 5
                    },
                    new AchievementData
                    {
                        Id = 16,
                        CompletedCount = 16,
                        CorrectCount = 11,
                        CurrentMark = 22,
                        TryCount = 1,
                        IdUserAchievement = 6
                    },
                    new AchievementData
                    {
                        Id = 17,
                        CompletedCount = 19,
                        CorrectCount = 14,
                        CurrentMark = 28,
                        TryCount = 2,
                        IdUserAchievement = 6
                    },
                    new AchievementData
                    {
                        Id = 18,
                        CompletedCount = 22,
                        CorrectCount = 17,
                        CurrentMark = 34,
                        TryCount = 3,
                        IdUserAchievement = 6
                    },
                    new AchievementData
                    {
                        Id = 19,
                        CompletedCount = 18,
                        CorrectCount = 13,
                        CurrentMark = 26,
                        TryCount = 1,
                        IdUserAchievement = 7
                    },
                    new AchievementData
                    {
                        Id = 20,
                        CompletedCount = 21,
                        CorrectCount = 16,
                        CurrentMark = 32,
                        TryCount = 2,
                        IdUserAchievement = 7
                    },
                    new AchievementData
                    {
                        Id = 21,
                        CompletedCount = 24,
                        CorrectCount = 19,
                        CurrentMark = 38,
                        TryCount = 3,
                        IdUserAchievement = 7
                    },
                    new AchievementData
                    {
                        Id = 22,
                        CompletedCount = 20,
                        CorrectCount = 15,
                        CurrentMark = 30,
                        TryCount = 1,
                        IdUserAchievement = 8
                    },
                    new AchievementData
                    {
                        Id = 23,
                        CompletedCount = 23,
                        CorrectCount = 18,
                        CurrentMark = 36,
                        TryCount = 2,
                        IdUserAchievement = 8
                    },
                    new AchievementData
                    {
                        Id = 24,
                        CompletedCount = 26,
                        CorrectCount = 21,
                        CurrentMark = 42,
                        TryCount = 3,
                        IdUserAchievement = 8
                    },
                    new AchievementData
                    {
                        Id = 25,
                        CompletedCount = 22,
                        CorrectCount = 17,
                        CurrentMark = 34,
                        TryCount = 1,
                        IdUserAchievement = 9
                    },
                    new AchievementData
                    {
                        Id = 26,
                        CompletedCount = 25,
                        CorrectCount = 20,
                        CurrentMark = 40,
                        TryCount = 2,
                        IdUserAchievement = 9
                    },
                    new AchievementData
                    {
                        Id = 27,
                        CompletedCount = 28,
                        CorrectCount = 23,
                        CurrentMark = 46,
                        TryCount = 3,
                        IdUserAchievement = 9
                    },
                    new AchievementData
                    {
                        Id = 28,
                        CompletedCount = 24,
                        CorrectCount = 19,
                        CurrentMark = 38,
                        TryCount = 1,
                        IdUserAchievement = 10
                    },
                    new AchievementData
                    {
                        Id = 29,
                        CompletedCount = 27,
                        CorrectCount = 22,
                        CurrentMark = 44,
                        TryCount = 2,
                        IdUserAchievement = 10
                    },
                    new AchievementData
                    {
                        Id = 30,
                        CompletedCount = 30,
                        CorrectCount = 25,
                        CurrentMark = 50,
                        TryCount = 3,
                        IdUserAchievement = 10
                    });
            });
        }
    }
}
