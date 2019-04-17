﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Quorum.DataAccess.Ef;

namespace Quorum.DataAccess.Ef.Migrations
{
    [DbContext(typeof(EfDataAccessContext))]
    partial class EfDataAccessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.ChallengedAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChallengedQuestionId");

                    b.Property<bool>("IsUserCorrect");

                    b.Property<int>("SourceAnswerId");

                    b.HasKey("Id");

                    b.HasIndex("ChallengedQuestionId");

                    b.HasIndex("SourceAnswerId");

                    b.ToTable("PassedAnswers");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.ChallengedQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChallengedTestId");

                    b.Property<int>("SourceQuestionId");

                    b.Property<int>("TotalScore");

                    b.Property<int>("UserScore");

                    b.HasKey("Id");

                    b.HasIndex("ChallengedTestId");

                    b.HasIndex("SourceQuestionId");

                    b.ToTable("PassedQuestions");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.ChallengedTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaximumScore");

                    b.Property<int>("SourceTestId");

                    b.Property<int>("TimeSpent");

                    b.Property<int>("UserScore");

                    b.HasKey("Id");

                    b.HasIndex("SourceTestId");

                    b.ToTable("PassedTests");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int?>("TestId");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("TimeLimit");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Answer", b =>
                {
                    b.HasOne("Quorum.BusinessCore.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.ChallengedAnswer", b =>
                {
                    b.HasOne("Quorum.BusinessCore.Entities.ChallengedQuestion")
                        .WithMany("Answers")
                        .HasForeignKey("ChallengedQuestionId");

                    b.HasOne("Quorum.BusinessCore.Entities.Answer", "SourceAnswer")
                        .WithMany()
                        .HasForeignKey("SourceAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.ChallengedQuestion", b =>
                {
                    b.HasOne("Quorum.BusinessCore.Entities.ChallengedTest")
                        .WithMany("Questions")
                        .HasForeignKey("ChallengedTestId");

                    b.HasOne("Quorum.BusinessCore.Entities.Question", "SourceQuestion")
                        .WithMany()
                        .HasForeignKey("SourceQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.ChallengedTest", b =>
                {
                    b.HasOne("Quorum.BusinessCore.Entities.Test", "SourceTest")
                        .WithMany()
                        .HasForeignKey("SourceTestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Question", b =>
                {
                    b.HasOne("Quorum.BusinessCore.Entities.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quorum.BusinessCore.Entities.Tag", b =>
                {
                    b.HasOne("Quorum.BusinessCore.Entities.Test")
                        .WithMany("Tags")
                        .HasForeignKey("TestId");
                });
#pragma warning restore 612, 618
        }
    }
}
