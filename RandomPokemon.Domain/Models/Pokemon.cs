using RandomPokemon.Domain.Enums;
using RandomPokemon.Domain.Shared;

namespace RandomPokemon.Domain.Models;

public class Pokemon : EntityBase
{
    public string Name { get; set; }
    public int PokedexId { get; set; }
    public EType TypeOne { get; set; }
    public EType? TypeTwo { get; set; }
    public byte[]? Image { get; set; }
    public byte[]? Silhouette { get; set; }
    public List<Pokemon> Evolutions { get; set; } = new List<Pokemon>();
}
