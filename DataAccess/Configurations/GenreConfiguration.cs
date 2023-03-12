using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations
{
    internal sealed class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder.HasKey(genre => genre.GenreId);
            builder.Property(genre => genre.GenreId).ValueGeneratedOnAdd();
            builder.Property(genre => genre.GenreName).IsRequired().HasMaxLength(150);
            builder.HasMany(genre => genre.FilmGenreLinks);
        }
    }
}
