﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesCrudOperation.Models;

namespace MoviesCrudOperation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210915143219_AddRangeToRate")]
    partial class AddRangeToRate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesCrudOperation.Models.Gener", b =>
                {
                    b.Property<int>("GenerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GenerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Geners");
                });

            modelBuilder.Entity("MoviesCrudOperation.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Poster")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Yera")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesCrudOperation.Models.Gener", b =>
                {
                    b.HasOne("MoviesCrudOperation.Models.Movie", null)
                        .WithMany("Geners")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("MoviesCrudOperation.Models.Movie", b =>
                {
                    b.Navigation("Geners");
                });
#pragma warning restore 612, 618
        }
    }
}
