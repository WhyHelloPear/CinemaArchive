using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    internal sealed class FilmGenreLinkConfiguration : IEntityTypeConfiguration<FilmGenreLinkEntity>
    {
        public void Configure(EntityTypeBuilder<FilmGenreLinkEntity> builder)
        {
            builder.HasIndex(link => new { link.FilmId, link.GenreId }).IsUnique();
            builder.Property(link => link.FilmId).IsRequired();
            builder.Property(link => link.GenreId).IsRequired();
            builder.HasOne(link => link.Genre);
            builder.HasOne(link => link.Film);
        }
    }
}
