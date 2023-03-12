using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess.Contexts
{
    public sealed class CinemaArchiveDbContext : DbContext
    {
        public DbSet<FilmEntity> FilmEntities { get; set; }
        public DbSet<GenreEntity> GenreEntities { get; set; }
        //public DbSet<FilmGenreLinkEntity> FilmGenreLinkEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //things to change
                //store connection string in appsetting and have the connection string injected into the context
                //enable encryption for sql server
            optionsBuilder.UseSqlServer("Server=localhost;Database=CinemaArchive;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmGenreLinkEntity>()
                .HasKey(e => new { e.FilmId, e.GenreId });
        }
    }
}
