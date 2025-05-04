using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RandomPokemon.Domain.Models;

namespace RandomPokemon.Data;

public class RandomPokemonDbContext : DbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }

    public RandomPokemonDbContext(DbContextOptions<RandomPokemonDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.PokedexId).IsRequired();
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Image);
            entity.Property(p => p.Silhouette);

            entity.HasMany(p => p.Evolutions)
                  .WithMany();
        });
    }
}
