using Game_Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game_Store.EntityConfig;

internal class GenreConfigurations : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired();

        builder.HasData(
            new Genre { Id = 1, Name = "Fighting"},
            new Genre { Id = 2, Name = "Roguelike"},
            new Genre { Id = 3, Name = "RPG"},
            new Genre { Id = 4, Name = "Shooter"},
            new Genre { Id = 5, Name = "Sports"},
            new Genre { Id = 6, Name = "Role-playing"},
            new Genre { Id = 7, Name = "Strategy"},
            new Genre { Id = 8, Name = "Survival"},
            new Genre { Id = 9, Name = "Puzzle"},
            new Genre { Id = 10, Name = "Simulation"},
            new Genre { Id = 11, Name = "Racing"},
            new Genre { Id = 12, Name = "Sandbox"},
            new Genre { Id = 13, Name = "Kids and Family"});
    }
}