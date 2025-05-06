using RandomPokemon.Domain.Models;

namespace RandomPokemon.Domain.Interfaces;

public interface IPokemonRepository
{
    Task<Pokemon?> GetPokemonByPokedexId(int pokedexId);
    Task<Pokemon?> GetPokemonByName(string name);
    Task<List<Pokemon>> GetAllPokemons();
}
