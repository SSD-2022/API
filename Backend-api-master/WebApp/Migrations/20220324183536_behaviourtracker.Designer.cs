﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

namespace WebApp.Migrations
{
    [DbContext(typeof(DbContext_dpal))]
    [Migration("20220324183536_behaviourtracker")]
    partial class behaviourtracker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.BehaviourTracker", b =>
                {
                    b.Property<string>("EmailAdd")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Agitation")
                        .HasColumnType("int");

                    b.Property<int>("Agression")
                        .HasColumnType("int");

                    b.Property<int>("Apathy")
                        .HasColumnType("int");

                    b.Property<int>("EatingProblems")
                        .HasColumnType("int");

                    b.Property<int>("ExcessiveCollecting")
                        .HasColumnType("int");

                    b.Property<int>("ExcessiveOrganizing")
                        .HasColumnType("int");

                    b.Property<int>("ImaginingThings")
                        .HasColumnType("int");

                    b.Property<int>("Impulsiveness")
                        .HasColumnType("int");

                    b.Property<int>("Incontinence")
                        .HasColumnType("int");

                    b.Property<int>("Repetition")
                        .HasColumnType("int");

                    b.Property<int>("ResistancetoCare")
                        .HasColumnType("int");

                    b.Property<int>("Restlessness")
                        .HasColumnType("int");

                    b.Property<int>("SafetyConcerns")
                        .HasColumnType("int");

                    b.Property<int>("Sleeping")
                        .HasColumnType("int");

                    b.Property<int>("Suspicion")
                        .HasColumnType("int");

                    b.Property<int>("Wandering")
                        .HasColumnType("int");

                    b.HasKey("EmailAdd");

                    b.ToTable("BehaviourTracker");
                });

            modelBuilder.Entity("WebApp.Models.RegisterUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contactnum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("RegisterDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TermCon")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RegisterUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RegisterUser");
                });

            modelBuilder.Entity("WebApp.Models.ProfileInfo", b =>
                {
                    b.HasBaseType("WebApp.Models.RegisterUser");

                    b.HasDiscriminator().HasValue("ProfileInfo");
                });

            modelBuilder.Entity("WebApp.Models.UserInfo", b =>
                {
                    b.HasBaseType("WebApp.Models.RegisterUser");

                    b.HasDiscriminator().HasValue("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
