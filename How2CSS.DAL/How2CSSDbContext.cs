using How2CSS.Core.Enums;
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
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<TagDistribution> TagDistributions { get; set; }
        public virtual DbSet<UnitDistribution> UnitDistributions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Metadata> Metadatas { get; set; }
        public virtual DbSet<Hint> Hints { get; set; }
        public virtual DbSet<CSSTask> Tasks { get; set; }
        public virtual DbSet<TaskDistribution> TaskDistributions { get; set; }
        public virtual DbSet<TaskResult> TaskResults { get; set; }
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

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTag");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Tag");

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasData(
                    new Tag 
                    {
                        Id = 1,
                        Name = "CSS"
                    });
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUnit");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Unit");

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.HasData(
                    new Unit 
                    {
                        Id = 1,
                        Name = "CSS"
                    });
            });

            modelBuilder.Entity<TagDistribution>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTagDistribution");

                entity.Property(e => e.Id)
                .HasColumnName("Id_TagDistribution");

                entity.HasOne(td => td.IdTagNavigation)
                .WithMany(t => t.TagDistributions)
                .HasForeignKey(td => td.IdTag)
                .HasConstraintName("R_4");

                entity.HasOne(td => td.IdMetadataNavigation)
                .WithMany(m => m.TagDistributions)
                .HasForeignKey(td => td.IdMetadata)
                .HasConstraintName("R_5");

                entity.HasData(
                    new TagDistribution 
                    {
                        Id = 1,
                        IdMetadata = 1,
                        IdTag = 1
                    });
            });

            modelBuilder.Entity<UnitDistribution>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKUnitDistribution");

                entity.Property(e => e.Id)
                .HasColumnName("Id_UnitDistribution");

                entity.HasOne(ud => ud.IdUnitNavigation)
                .WithMany(u => u.UnitDistributions)
                .HasForeignKey(ud => ud.IdUnit)
                .HasConstraintName("R_6");

                entity.HasOne(ud => ud.IdMetadataNavigation)
                .WithMany(m => m.UnitDistributions)
                .HasForeignKey(ud => ud.IdMetadata)
                .HasConstraintName("R_7");

                entity.HasData(
                    new UnitDistribution 
                    {
                        Id = 1,
                        IdMetadata = 1,
                        IdUnit = 1
                    });
            });

            modelBuilder.Entity<Metadata>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKMetadata");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Metadata");

                entity.HasData(
                    new Metadata 
                    {
                        Id = 1
                    });
            });

            modelBuilder.Entity<Question>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKQuestion");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Question");

                entity.Property(e => e.QuestionText)
                .HasMaxLength(500)
                .IsUnicode(false);

                entity.HasData(
                    new Question 
                    {
                        Id = 1,
                        QuestionText = "CSS"
                    });
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKAnswer");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Answer");

                entity.Property(e => e.EtalonAnswer)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasData(
                    new Answer 
                    {
                        Id = 1,
                        EtalonAnswer = "CSS"
                    });
            });

            modelBuilder.Entity<Hint>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKHint");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Hint");

                entity.Property(e => e.HintType)
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.HintText)
                .HasMaxLength(200)
                .IsUnicode(false);

                entity.HasOne(h => h.IdTaskNavigation)
                .WithMany(t => t.Hints)
                .HasForeignKey(h => h.IdTask)
                .HasConstraintName("R_8");

                entity.HasData(
                    new Hint 
                    {
                        Id = 1,
                        IdTask = 1,
                        HintType = "CSS",
                        HintText = "CSS"
                    });
            });

            modelBuilder.Entity<CSSTask>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTask");

                entity.Property(e => e.Id)
                .HasColumnName("Id_Task");

                entity.HasOne(t => t.IdAnswerNavigation)
                .WithMany(a => a.Tasks)
                .HasForeignKey(t => t.IdAnswer)
                .HasConstraintName("R_9");

                entity.HasOne(t => t.IdQuestionNavigation)
                .WithMany(q => q.Tasks)
                .HasForeignKey(t => t.IdQuestion)
                .HasConstraintName("R_10");

                entity.HasOne(t => t.IdMetadataNavigation)
                .WithMany(m => m.Tasks)
                .HasForeignKey(t => t.IdMetadata)
                .HasConstraintName("R_11");

                entity.HasData(
                    new CSSTask 
                    {
                        Id = 1,
                        IdAnswer = 1,
                        IdMetadata = 1,
                        IdQuestion = 1
                    });
            });

            modelBuilder.Entity<TaskDistribution>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTaskDistribution");

                entity.Property(e => e.Id)
                .HasColumnName("Id_TaskDistribution");

                entity.HasOne(tsd => tsd.IdLevelNavigation)
                .WithMany(l => l.TaskDistributions)
                .HasForeignKey(tsd => tsd.IdLevel)
                .HasConstraintName("R_12");

                entity.HasOne(tsd => tsd.IdTaskNavigation)
                .WithMany(t => t.TaskDistributions)
                .HasForeignKey(tsd => tsd.IdTask)
                .HasConstraintName("R_13");
            });

            modelBuilder.Entity<TaskResult>(entity => 
            {
                entity.HasKey(e => e.Id)
                .HasName("XPKTaskResult");

                entity.Property(e => e.Id)
                .HasColumnName("Id_TaskResult");

                entity.Property(e => e.UserAnswer)
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.HasOne(tr => tr.IdTaskNavigation)
                .WithMany(t => t.TaskResults)
                .HasForeignKey(tr => tr.IdTask)
                .HasConstraintName("R_14");

                entity.HasOne(tr => tr.IdUserNavigation)
                .WithMany(u => u.TaskResults)
                .HasForeignKey(tr => tr.IdUser)
                .HasConstraintName("R_15");

                entity.HasData(
                    new TaskResult 
                    {
                        Id = 1,
                        IdUser = 1,
                        IdTask = 1,
                        ResultDate = new DateTime(2000,8,11),
                        Duration = 10000,
                        UserAnswer = "CSS",
                        Score = 25
                    });
            });
        }
    }
}
