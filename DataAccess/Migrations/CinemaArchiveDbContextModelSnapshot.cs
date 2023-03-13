﻿// <auto-generated />
using System;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(CinemaArchiveDbContext))]
    partial class CinemaArchiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenreLink");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmPersonLinkEntity", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "PersonId", "RoleId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("FilmPersonLink");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmRoleEntity", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("FilmRoleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId");

                    b.HasIndex("FilmRoleTitle")
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

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Infrastructure.DataAccess.Entities.FilmGenreLinkEntity", b =>
                {
                    b.HasOne("Infrastructure.DataAccess.Entities.FilmEntity", "Film")
                        .WithMany()
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
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataAccess.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.DataAccess.Entities.FilmRoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Person");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
