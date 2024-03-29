﻿// <auto-generated />
using System;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(CinemaArchiveDbContext))]
    [Migration("20230407014835_UpdateColumnNames")]
    partial class UpdateColumnNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmEntity", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<string>("FilmTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FilmId");

                    b.HasIndex("FilmTitle", "ReleaseDate")
                        .IsUnique()
                        .HasDatabaseName("UQ_Film_TitleReleaseDate");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmGenreLinkEntity", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("FilmId", "GenreId"));

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenreLink");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmPersonLinkEntity", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("FilmRoleId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "PersonId", "FilmRoleId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("FilmId", "PersonId", "FilmRoleId"));

                    b.HasIndex("FilmRoleId");

                    b.HasIndex("PersonId");

                    b.ToTable("FilmPersonLink");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmRoleEntity", b =>
                {
                    b.Property<int>("FilmRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmRoleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmRoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FilmRoleId");

                    b.HasIndex("FilmRoleName")
                        .IsUnique()
                        .HasDatabaseName("UQ_FilmRole_FilmRoleTitle");

                    b.ToTable("FilmRole");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.GenreEntity", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GenreId");

                    b.HasIndex("GenreName")
                        .IsUnique()
                        .HasDatabaseName("UQ_Genre_GenreName");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.PersonEntity", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmGenreLinkEntity", b =>
                {
                    b.HasOne("Infrastructure.DataAccess.Entities.FilmEntity", "Film")
                        .WithMany("FilmGenreLinks")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataAccess.Entities.GenreEntity", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmPersonLinkEntity", b =>
                {
                    b.HasOne("Infrastructure.DataAccess.Entities.FilmEntity", "Film")
                        .WithMany("FilmPersonLinks")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataAccess.Entities.FilmRoleEntity", "FilmRole")
                        .WithMany()
                        .HasForeignKey("FilmRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataAccess.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("FilmRole");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmEntity", b =>
                {
                    b.Navigation("FilmGenreLinks");

                    b.Navigation("FilmPersonLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
