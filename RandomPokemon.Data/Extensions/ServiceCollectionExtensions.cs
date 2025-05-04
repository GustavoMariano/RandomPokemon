using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RandomPokemon.Data.Repositories;
using RandomPokemon.Domain.Interfaces;

namespace RandomPokemon.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddDbContext<RandomPokemonDbContext>(options =>
            options.UseSqlite("Data Source=pokemon.db"));
        services.AddScoped<IPokemonRepository, PokemonRepository>();
        return services;
    }
}
