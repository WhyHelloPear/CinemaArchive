using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    internal sealed class FilmConfiguration : IEntityTypeConfiguration<FilmEntity>
    {
        public void Configure(EntityTypeBuilder<FilmEntity> builder)
        {
            builder.HasIndex(f => new { f.FilmTitle, f.ReleaseDate }).IsUnique();
            builder.Property(f => f.FilmId).ValueGeneratedOnAdd();
            builder.Property(f => f.FilmTitle).IsRequired().HasMaxLength(150);
            builder.Property(f => f.ReleaseDate).IsRequired();
            builder.HasMany(f => f.FilmGenreLinks);
        }
    }
}
