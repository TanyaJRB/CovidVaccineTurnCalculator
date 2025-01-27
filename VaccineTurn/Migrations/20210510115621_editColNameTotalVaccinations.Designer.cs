﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccineTurn.Data;

namespace VaccineTurn.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210510115621_editColNameTotalVaccinations")]
    partial class editColNameTotalVaccinations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VaccineTurn.Models.DailyRate", b =>
                {
                    b.Property<int>("DailyRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentRate")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PopulationGroupsId")
                        .HasColumnType("int");

                    b.HasKey("DailyRateId");

                    b.HasIndex("PopulationGroupsId");

                    b.ToTable("DailyRate");
                });

            modelBuilder.Entity("VaccineTurn.Models.PopulationGroups", b =>
                {
                    b.Property<int>("PopulationGroupsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeGroupMax")
                        .HasColumnType("int");

                    b.Property<int>("AgeGroupMin")
                        .HasColumnType("int");

                    b.Property<int>("NumberPeople")
                        .HasColumnType("int");

                    b.HasKey("PopulationGroupsId");

                    b.ToTable("PopulationGroups");
                });

            modelBuilder.Entity("VaccineTurn.Models.Targets", b =>
                {
                    b.Property<int>("TargetsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysRemaining")
                        .HasColumnType("int");

                    b.Property<DateTime>("TargetDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TargetFirstDoses")
                        .HasColumnType("int");

                    b.Property<int>("TargetWeeklyRate")
                        .HasColumnType("int");

                    b.HasKey("TargetsId");

                    b.ToTable("Targets");
                });

            modelBuilder.Entity("VaccineTurn.Models.TotalVaccinations", b =>
                {
                    b.Property<int>("TotalVaccinationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalDoses")
                        .HasColumnType("int");

                    b.Property<string>("VaccType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TotalVaccinationsId");

                    b.ToTable("TotalVaccinations");
                });

            modelBuilder.Entity("VaccineTurn.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VaccineTurn.Models.DailyRate", b =>
                {
                    b.HasOne("VaccineTurn.Models.PopulationGroups", "PopulationGroups")
                        .WithMany("DailyRate")
                        .HasForeignKey("PopulationGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PopulationGroups");
                });

            modelBuilder.Entity("VaccineTurn.Models.PopulationGroups", b =>
                {
                    b.Navigation("DailyRate");
                });
#pragma warning restore 612, 618
        }
    }
}
