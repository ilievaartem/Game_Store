using Game_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game_Store.EntityConfig;

internal class GamesConfigurations : IEntityTypeConfiguration<GameSummary>
{
    public void Configure(EntityTypeBuilder<GameSummary> builder)
    {
        builder.HasKey(e => e.GameId);
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Genre).IsRequired();
        builder.Property(e => e.Price);
        builder.Property(e => e.ReleaseDate).IsRequired();

        builder.HasData(
            new GameSummary
            {
                GameId = 1, Name = "TBoI: Repentance", Genres = "Roguelike", Price = 1499M,
                ReleaseDate = new DateOnly(2021, 3, 31)
            },
            new GameSummary { GameId = 2, Name = "CS2", Genres = "Shooter", Price = 0,
                ReleaseDate = new DateOnly(2023, 9, 27)
            }
        );
    }
}
