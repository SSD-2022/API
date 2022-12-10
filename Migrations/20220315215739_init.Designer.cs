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
    [Migration("20220315215739_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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
                });
#pragma warning restore 612, 618
        }
    }
}