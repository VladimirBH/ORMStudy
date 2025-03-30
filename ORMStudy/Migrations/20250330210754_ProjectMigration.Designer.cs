﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORMStudy.DataBase;

#nullable disable

namespace ORMStudy.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250330210754_ProjectMigration")]
    partial class ProjectMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ORMStudy.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("lastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Mentor");
                });

            modelBuilder.Entity("ORMStudy.Models.Project", b =>
                {
                    b.Property<int>("Shifr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shifr");

                    b.Property<DateOnly>("DateStart")
                        .HasColumnType("date")
                        .HasColumnName("dateStart");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("project");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("topic");

                    b.HasKey("Shifr");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ORMStudy.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("lastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<int>("team")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("team");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ORMStudy.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("team");

                    b.Property<int>("mentor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("mentor");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ORMStudy.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("result");

                    b.Property<int>("Takt")
                        .HasColumnType("int")
                        .HasColumnName("takt");

                    b.Property<int>("project_shifr")
                        .HasColumnType("int");

                    b.Property<int>("student_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("project_shifr");

                    b.HasIndex("student_id");

                    b.ToTable("Work");
                });

            modelBuilder.Entity("ORMStudy.Models.Students", b =>
                {
                    b.HasOne("ORMStudy.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("team")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ORMStudy.Models.Team", b =>
                {
                    b.HasOne("ORMStudy.Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("mentor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("ORMStudy.Models.Work", b =>
                {
                    b.HasOne("ORMStudy.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("project_shifr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORMStudy.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
