using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess.Contexts
{
    public sealed class CinemaArchiveDbContext : DbContext
    {
        public DbSet<FilmEntity> FilmEntities { get; set; }
        public DbSet<GenreEntity> GenreEntities { get; set; }
        public DbSet<FilmRoleEntity> FilmRoleEntities { get; set; }
        public DbSet<PersonEntity> PersonEntities { get; set; }
        public DbSet<FilmGenreLinkEntity> FilmGenreLinkEntities { get; set; }
        public DbSet<FilmPersonLinkEntity> FilmPersonLinkEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //things to change
                //store connection string in appsetting and have the connection string injected into the context
                //enable encryption for sql server
            optionsBuilder.UseSqlServer("Server=localhost;Database=CinemaArchive;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmEntity>()
                .HasIndex(film => new {film.FilmTitle, film.ReleaseDate})
                .IsUnique()
                .HasDatabaseName("UQ_Film_TitleReleaseDate");

            modelBuilder.Entity<GenreEntity>()
                .HasIndex(genre=>genre.GenreName)
                .IsUnique()
                .HasDatabaseName("UQ_Genre_GenreName");

            modelBuilder.Entity<FilmRoleEntity>()
                .HasIndex(genre => genre.FilmRoleTitle)
                .IsUnique()
                .HasDatabaseName("UQ_FilmRole_FilmRoleTitle");

            modelBuilder.Entity<FilmGenreLinkEntity>()
                .HasKey(e => new { e.FilmId, e.GenreId });
            
            modelBuilder.Entity<FilmPersonLinkEntity>()
                .HasKey(e => new { e.FilmId, e.PersonId, e.RoleId });
        }
    }
}
