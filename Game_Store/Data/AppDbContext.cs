using Game_Store.EntityConfig;
using Game_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Data;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"));
    }
    
    public DbSet<GameSummary> Games { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Transactions> Transactions { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<UserGame> UserGames { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GameSummary>()
            .HasKey(gs => gs.GameId);
        
        modelBuilder.ApplyConfiguration(new TransactionsConfigurations());
        modelBuilder.ApplyConfiguration(new UsersConfigurations());
        modelBuilder.ApplyConfiguration(new GenreConfigurations());
        
        modelBuilder.Entity<GameSummary>()
            .HasOne(g => g.Genre)
            .WithMany(g => g.Games)
            .HasForeignKey(g => g.GenreID);

        modelBuilder.Entity<Transactions>()
            .HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId);

        modelBuilder.Entity<Transactions>()
            .HasOne(t => t.Game)
            .WithMany()
            .HasForeignKey(t => t.GameId);    
        
        modelBuilder.Entity<UserGame>()
            .HasKey(ug => new { ug.UserId, ug.GameId });

        modelBuilder.Entity<UserGame>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.UserGames)
            .HasForeignKey(ug => ug.UserId);

        modelBuilder.Entity<UserGame>()
            .HasOne(ug => ug.Game)
            .WithMany(g => g.UserGames)
            .HasForeignKey(ug => ug.GameId);
    }
}