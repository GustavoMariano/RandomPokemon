namespace RandomPokemon.Contracts.Dtos;

public class PokemonDto
{
    public string Name { get; set; }
    public int PokedexId { get; set; }
    public string TypeOne { get; set; }
    public string? TypeTwo { get; set; }
    public byte[]? Image { get; set; }
    public byte[]? Silhouette { get; set; }
    public List<PokemonDto> Evolutions { get; set; }
}
