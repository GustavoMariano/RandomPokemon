using System.Text.Json.Serialization;

namespace RandomPokemon.WebSite.Models;

public class Pokemon
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("pokedexId")]
    public int PokedexId { get; set; }
    [JsonPropertyName("typeOne")]
    public string TypeOne { get; set; }
    [JsonPropertyName("typeTwo")]
    public string? TypeTwo { get; set; }
    [JsonPropertyName("image")]
    public byte[]? Image { get; set; }
    [JsonPropertyName("silhouette")]
    public byte[]? Silhouette { get; set; }
    [JsonPropertyName("evolutions")]
    public List<Pokemon> Evolutions { get; set; } = new List<Pokemon>();
}