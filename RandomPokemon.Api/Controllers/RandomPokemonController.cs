using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RandomPokemon.Contracts.Dtos;
using RandomPokemon.Services.Services;

namespace RandomPokemon.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomPokemonController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly PokemonService _pokemonService;

    public RandomPokemonController(PokemonService pokemonService, IMapper mapper)
    {
        _pokemonService = pokemonService;
        _mapper = mapper;
    }

    [HttpGet("random", Name = "RandomPokemon")]
    public async Task<ActionResult<PokemonDto>> GetAsync()
    {
        var pokemon = await _pokemonService.GetRandomPokemon(new Random().Next(1, 152));
        return Ok(pokemon);
    }

    [HttpGet("byPokedexId", Name = "GetPokemon")]
    public async Task<ActionResult<PokemonDto>> GetByIdAsync(int pokedexId)
    {
        var pokemon = await _pokemonService.GetPokemonByPokedexId(pokedexId);
        return Ok(pokemon);
    }

    [HttpGet("all", Name = "AllPokemons")]
    public async Task<ActionResult<List<PokemonDto>>> GetAllAsync()
    {
        var pokemons = await _pokemonService.GetAllPokemons();
        return Ok(pokemons);
    }
}
