using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts
{
    public sealed class CinemaArchiveDbContext : DbContext
    {
        public CinemaArchiveDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<FilmEntity> FilmEntities { get; set; }
        public DbSet<GenreEntity> GenreEntities { get; set; }
        public DbSet<FilmGenreLinkEntity> FilmGenreLinkEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaArchiveDbContext).Assembly);
    }
}
