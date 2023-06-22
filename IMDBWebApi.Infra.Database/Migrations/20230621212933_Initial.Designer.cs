﻿// <auto-generated />
using System;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IMDBWebApi.Infra.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230621212933_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHashSalt")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varbinary(32)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varbinary(12)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.AssessmentRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommonUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EvaluationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommonUserId");

                    b.HasIndex("MovieId");

                    b.ToTable("AssessmentRecords");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Casts");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.CastActMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CastActId")
                        .HasColumnType("int");

                    b.Property<int>("MovieActId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CastActId");

                    b.HasIndex("MovieActId");

                    b.ToTable("CastActMovies");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.CastDirectMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CastDirectorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieDirectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CastDirectorId");

                    b.HasIndex("MovieDirectId");

                    b.ToTable("CastDirectMovies");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.CommonUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHashSalt")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varbinary(32)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varbinary(12)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("CommonUsers");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.GenreMovies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("GenreMovies");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Duration")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<double>("RatingAverage")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(4, 2)
                        .HasColumnType("float(4)")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalVotes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.AssessmentRecord", b =>
                {
                    b.HasOne("IMDBWebApi.Domain.Entities.CommonUser", "CommonUser")
                        .WithMany("Assessments")
                        .HasForeignKey("CommonUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMDBWebApi.Domain.Entities.Movie", "Movie")
                        .WithMany("Assessments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommonUser");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.CastActMovies", b =>
                {
                    b.HasOne("IMDBWebApi.Domain.Entities.Cast", "CastAct")
                        .WithMany("ActedMovies")
                        .HasForeignKey("CastActId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMDBWebApi.Domain.Entities.Movie", "MovieAct")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieActId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CastAct");

                    b.Navigation("MovieAct");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.CastDirectMovies", b =>
                {
                    b.HasOne("IMDBWebApi.Domain.Entities.Cast", "CastDirector")
                        .WithMany("DirectedMovies")
                        .HasForeignKey("CastDirectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IMDBWebApi.Domain.Entities.Movie", "MovieDirect")
                        .WithMany("DirectorMovies")
                        .HasForeignKey("MovieDirectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CastDirector");

                    b.Navigation("MovieDirect");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.GenreMovies", b =>
                {
                    b.HasOne("IMDBWebApi.Domain.Entities.Genre", "Genre")
                        .WithMany("GenreMovies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMDBWebApi.Domain.Entities.Movie", "Movie")
                        .WithMany("GenresMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Cast", b =>
                {
                    b.Navigation("ActedMovies");

                    b.Navigation("DirectedMovies");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.CommonUser", b =>
                {
                    b.Navigation("Assessments");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Genre", b =>
                {
                    b.Navigation("GenreMovies");
                });

            modelBuilder.Entity("IMDBWebApi.Domain.Entities.Movie", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("Assessments");

                    b.Navigation("DirectorMovies");

                    b.Navigation("GenresMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
