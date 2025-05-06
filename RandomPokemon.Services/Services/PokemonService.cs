using AutoMapper;
using RandomPokemon.Contracts.Dtos;
using RandomPokemon.Domain.Interfaces;

namespace RandomPokemon.Services.Services;

public class PokemonService
{
    private readonly IPokemonRepository _repository;
    private readonly IMapper _mapper;

    public PokemonService(IPokemonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PokemonDto?> GetPokemonByPokedexId(int pokedexId)
    {
        var pokemon = await _repository.GetPokemonByPokedexId(pokedexId);
        if (pokemon == null)
            return null;

        return _mapper.Map<PokemonDto>(pokemon);
    }

    public async Task<List<PokemonDto>> GetAllPokemons()
    {
        var pokemons = await _repository.GetAllPokemons();

        return _mapper.Map<List<PokemonDto>>(pokemons);
    }

    public async Task<PokemonDto?> GetPokemonByName(string name)
    {
        var pokemon = await _repository.GetPokemonByName(name);
        if (pokemon == null)
            return null;

        return _mapper.Map<PokemonDto>(pokemon);
    }
}
