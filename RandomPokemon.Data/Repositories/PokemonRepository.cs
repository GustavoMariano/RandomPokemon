using Microsoft.EntityFrameworkCore;
using RandomPokemon.Domain.Interfaces;
using RandomPokemon.Domain.Models;

namespace RandomPokemon.Data.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly RandomPokemonDbContext _context;

    public PokemonRepository(RandomPokemonDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pokemon>> GetAllPokemons()
    {
        return await _context.Pokemons
            .Include(p => p.Evolutions)
            .ToListAsync();
    }

    public async Task<Pokemon?> GetPokemonByPokedexId(int pokedexId)
    {
        return await _context.Pokemons
            .Include(p => p.Evolutions)
            .FirstOrDefaultAsync(p => p.PokedexId == pokedexId);
    }

    public async Task<Pokemon?> GetRandomPokemon(int pokedexId)
    {
        return await _context.Pokemons
            .Include(p => p.Evolutions)
            .FirstOrDefaultAsync(p => p.PokedexId == pokedexId);
    }
}
