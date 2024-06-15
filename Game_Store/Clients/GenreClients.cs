using Game_Store.Models;

namespace Game_Store.Clients;

public class GenreClients
{
    private readonly Genre[] genres =
    [
        new ()
        {
            Id = 1,
            Name = "Fighting"
        },
        new ()
        {
            Id = 2,
            Name = "Roguelike"
        },
        new ()
        {
            Id = 3,
            Name = "Shooter"
        },
        new ()
        {
            Id = 4,
            Name = "RPG"
        },
        new ()
        {
            Id = 5,
            Name = "Kids and Family"
        }
    ];

    public Genre[] GetGenres() => genres;   
}