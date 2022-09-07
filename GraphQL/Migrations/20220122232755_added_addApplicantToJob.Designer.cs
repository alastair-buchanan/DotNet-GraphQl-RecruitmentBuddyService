﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentBuddy.GraphQL.Data;

namespace RecruitmentBuddy.GraphQL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220122232755_added_addApplicantToJob")]
    partial class added_addApplicantToJob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AboutMe")
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobStatus")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.JobApplicant", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("JobId", "ApplicantId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("JobApplicant");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateStarted")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProficiencyLevel")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.Job", b =>
                {
                    b.HasOne("RecruitmentBuddy.GraphQL.Data.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.JobApplicant", b =>
                {
                    b.HasOne("RecruitmentBuddy.GraphQL.Data.Applicant", "Applicant")
                        .WithMany("JobApplicants")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentBuddy.GraphQL.Data.Job", "Job")
                        .WithMany("JobApplicants")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.ProgrammingLanguage", b =>
                {
                    b.HasOne("RecruitmentBuddy.GraphQL.Data.Applicant", null)
                        .WithMany("ProgrammingLanguages")
                        .HasForeignKey("ApplicantId");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.Applicant", b =>
                {
                    b.Navigation("JobApplicants");

                    b.Navigation("ProgrammingLanguages");
                });

            modelBuilder.Entity("RecruitmentBuddy.GraphQL.Data.Job", b =>
                {
                    b.Navigation("JobApplicants");
                });
#pragma warning restore 612, 618
        }
    }
}
