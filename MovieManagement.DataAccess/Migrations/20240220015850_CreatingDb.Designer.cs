﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManagement.DataAccess;

#nullable disable

namespace MovieManagement.DataAccess.Migrations
{
    [DbContext(typeof(MovieManagementDbContext))]
    [Migration("20240220015850_CreatingDb")]
    partial class CreatingDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("GenreId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MovieManagement.Domain.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb18b983-31fb-451e-b51f-59bac7de419f"),
                            FirstName = "Chuck",
                            LastName = "Norris"
                        },
                        new
                        {
                            Id = new Guid("974da171-be2f-44f6-860c-f7be0f372f33"),
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = new Guid("417e8e49-8564-4286-a4a3-19e1162c4a0d"),
                            FirstName = "Van",
                            LastName = "Damme"
                        });
                });

            modelBuilder.Entity("MovieManagement.Domain.Biography", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ActorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActorId")
                        .IsUnique();

                    b.ToTable("Biographies");
                });

            modelBuilder.Entity("MovieManagement.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MovieManagement.Domain.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ActorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0f55b9a-e91a-4a19-a274-0bfb5141b265"),
                            ActorId = new Guid("bb18b983-31fb-451e-b51f-59bac7de419f"),
                            Description = "Box Office Open Soon",
                            Name = "Wakanda Forever"
                        },
                        new
                        {
                            Id = new Guid("2714d610-7f90-4ba7-bcec-ccab0dd9de83"),
                            ActorId = new Guid("974da171-be2f-44f6-860c-f7be0f372f33"),
                            Description = "Box Office Open Soon",
                            Name = "Wakanda Forever"
                        },
                        new
                        {
                            Id = new Guid("a6f15d6f-dcc4-4eda-9e7d-edabed957b04"),
                            ActorId = new Guid("bb18b983-31fb-451e-b51f-59bac7de419f"),
                            Description = "Sky Scrapper be warned",
                            Name = "Spiderman"
                        },
                        new
                        {
                            Id = new Guid("cddb4996-ee44-4406-bfe4-af0706b785bc"),
                            ActorId = new Guid("417e8e49-8564-4286-a4a3-19e1162c4a0d"),
                            Description = "Blue or Red Pill",
                            Name = "Matrix"
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("MovieManagement.Domain.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieManagement.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieManagement.Domain.Biography", b =>
                {
                    b.HasOne("MovieManagement.Domain.Actor", "Actor")
                        .WithOne("Biography")
                        .HasForeignKey("MovieManagement.Domain.Biography", "ActorId");

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("MovieManagement.Domain.Movie", b =>
                {
                    b.HasOne("MovieManagement.Domain.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId");

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("MovieManagement.Domain.Actor", b =>
                {
                    b.Navigation("Biography");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
