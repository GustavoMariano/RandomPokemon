using RandomPokemon.Domain.Models;

namespace RandomPokemon.Domain.Interfaces;

public interface IPokemonRepository
{
    Task<Pokemon?> GetRandomPokemon(int pokedexId);
    Task<Pokemon?> GetPokemonByPokedexId(int pokedexId);
    Task<List<Pokemon>> GetAllPokemons();
}
