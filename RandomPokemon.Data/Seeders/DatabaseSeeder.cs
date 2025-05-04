using RandomPokemon.Data;
using RandomPokemon.Domain.Models;

public static class DatabaseSeeder
{
    public static async Task SeedData(RandomPokemonDbContext context)
    {
        string basePath = @"C:\Users\gusta\Desktop\pokemons";
        var pokemons = new (string Name, int PokedexId, EType TypeOne, EType? TypeTwo)[]
        {
            ("Bulbasaur", 1, EType.Grass, EType.Poison),
            ("Ivysaur", 2, EType.Grass, EType.Poison),
            ("Venusaur", 3, EType.Grass, EType.Poison),
            ("Charmander", 4, EType.Fire, null),
            ("Charmeleon", 5, EType.Fire, null),
            ("Charizard", 6, EType.Fire, EType.Flying),
            ("Squirtle", 7, EType.Water, null),
            ("Wartortle", 8, EType.Water, null),
            ("Blastoise", 9, EType.Water, null),
            ("Caterpie", 10, EType.Bug, null),
            ("Metapod", 11, EType.Bug, null),
            ("Butterfree", 12, EType.Bug, EType.Flying),
            ("Weedle", 13, EType.Bug, EType.Poison),
            ("Kakuna", 14, EType.Bug, EType.Poison),
            ("Beedrill", 15, EType.Bug, EType.Poison),
            ("Pidgey", 16, EType.Normal, EType.Flying),
            ("Pidgeotto", 17, EType.Normal, EType.Flying),
            ("Pidgeot", 18, EType.Normal, EType.Flying),
            ("Rattata", 19, EType.Normal, null),
            ("Raticate", 20, EType.Normal, null),
            ("Spearow", 21, EType.Normal, EType.Flying),
            ("Fearow", 22, EType.Normal, EType.Flying),
            ("Ekans", 23, EType.Poison, null),
            ("Arbok", 24, EType.Poison, null),
            ("Pikachu", 25, EType.Electric, null),
            ("Raichu", 26, EType.Electric, null),
            ("Sandshrew", 27, EType.Ground, null),
            ("Sandslash", 28, EType.Ground, null),
            ("Nidoran", 29, EType.Poison, null),
            ("Nidorina", 30, EType.Poison, null),
            ("Nidoqueen", 31, EType.Poison, EType.Ground),
            ("Nidoran", 32, EType.Poison, null),
            ("Nidorino", 33, EType.Poison, null),
            ("Nidoking", 34, EType.Poison, EType.Ground),
            ("Clefairy", 35, EType.Fairy, null),
            ("Clefable", 36, EType.Fairy, null),
            ("Vulpix", 37, EType.Fire, null),
            ("Ninetales", 38, EType.Fire, null),
            ("Jigglypuff", 39, EType.Normal, EType.Fairy),
            ("Wigglytuff", 40, EType.Normal, EType.Fairy),
            ("Zubat", 41, EType.Poison, EType.Flying),
            ("Golbat", 42, EType.Poison, EType.Flying),
            ("Oddish", 43, EType.Grass, EType.Poison),
            ("Gloom", 44, EType.Grass, EType.Poison),
            ("Vileplume", 45, EType.Grass, EType.Poison),
            ("Paras", 46, EType.Bug, EType.Grass),
            ("Parasect", 47, EType.Bug, EType.Grass),
            ("Venonat", 48, EType.Bug, EType.Poison),
            ("Venomoth", 49, EType.Bug, EType.Poison),
            ("Diglett", 50, EType.Ground, null),
            ("Dugtrio", 51, EType.Ground, null),
            ("Meowth", 52, EType.Normal, null),
            ("Persian", 53, EType.Normal, null),
            ("Psyduck", 54, EType.Water, null),
            ("Golduck", 55, EType.Water, null),
            ("Mankey", 56, EType.Fighting, null),
            ("Primeape", 57, EType.Fighting, null),
            ("Growlithe", 58, EType.Fire, null),
            ("Arcanine", 59, EType.Fire, null),
            ("Poliwag", 60, EType.Water, null),
            ("Poliwhirl", 61, EType.Water, null),
            ("Poliwrath", 62, EType.Water, EType.Fighting),
            ("Abra", 63, EType.Psychic, null),
            ("Kadabra", 64, EType.Psychic, null),
            ("Alakazam", 65, EType.Psychic, null),
            ("Machop", 66, EType.Fighting, null),
            ("Machoke", 67, EType.Fighting, null),
            ("Machamp", 68, EType.Fighting, null),
            ("Bellsprout", 69, EType.Grass, EType.Poison),
            ("Weepinbell", 70, EType.Grass, EType.Poison),
            ("Victreebel", 71, EType.Grass, EType.Poison),
            ("Tentacool", 72, EType.Water, EType.Poison),
            ("Tentacruel", 73, EType.Water, EType.Poison),
            ("Geodude", 74, EType.Rock, EType.Ground),
            ("Graveler", 75, EType.Rock, EType.Ground),
            ("Golem", 76, EType.Rock, EType.Ground),
            ("Ponyta", 77, EType.Fire, null),
            ("Rapidash", 78, EType.Fire, null),
            ("Slowpoke", 79, EType.Water, EType.Psychic),
            ("Slowbro", 80, EType.Water, EType.Psychic),
            ("Magnemite", 81, EType.Electric, EType.Steel),
            ("Magneton", 82, EType.Electric, EType.Steel),
            ("Farfetch'd", 83, EType.Normal, EType.Flying),
            ("Doduo", 84, EType.Normal, EType.Flying),
            ("Dodrio", 85, EType.Normal, EType.Flying),
            ("Seel", 86, EType.Water, null),
            ("Dewgong", 87, EType.Water, EType.Ice),
            ("Grimer", 88, EType.Poison, null),
            ("Muk", 89, EType.Poison, null),
            ("Shellder", 90, EType.Water, null),
            ("Cloyster", 91, EType.Water, EType.Ice),
            ("Gastly", 92, EType.Ghost, EType.Poison),
            ("Haunter", 93, EType.Ghost, EType.Poison),
            ("Gengar", 94, EType.Ghost, EType.Poison),
            ("Onix", 95, EType.Rock, EType.Ground),
            ("Drowzee", 96, EType.Psychic, null),
            ("Hypno", 97, EType.Psychic, null),
            ("Krabby", 98, EType.Water, null),
            ("Kingler", 99, EType.Water, null),
            ("Voltorb", 100, EType.Electric, null),
            ("Electrode", 101, EType.Electric, null),
            ("Exeggcute", 102, EType.Grass, EType.Psychic),
            ("Exeggutor", 103, EType.Grass, EType.Psychic),
            ("Cubone", 104, EType.Ground, null),
            ("Marowak", 105, EType.Ground, null),
            ("Hitmonlee", 106, EType.Fighting, null),
            ("Hitmonchan", 107, EType.Fighting, null),
            ("Lickitung", 108, EType.Normal, null),
            ("Koffing", 109, EType.Poison, null),
            ("Weezing", 110, EType.Poison, null),
            ("Rhyhorn", 111, EType.Ground, EType.Rock),
            ("Rhydon", 112, EType.Ground, EType.Rock),
            ("Chansey", 113, EType.Normal, null),
            ("Tangela", 114, EType.Grass, null),
            ("Kangaskhan", 115, EType.Normal, null),
            ("Horsea", 116, EType.Water, null),
            ("Seadra", 117, EType.Water, null),
            ("Goldeen", 118, EType.Water, null),
            ("Seaking", 119, EType.Water, null),
            ("Staryu", 120, EType.Water, null),
            ("Starmie", 121, EType.Water, EType.Psychic),
            ("Mr. Mime", 122, EType.Psychic, EType.Fairy),
            ("Scyther", 123, EType.Bug, EType.Flying),
            ("Jynx", 124, EType.Ice, EType.Psychic),
            ("Electabuzz", 125, EType.Electric, null),
            ("Magmar", 126, EType.Fire, null),
            ("Pinsir", 127, EType.Bug, null),
            ("Tauros", 128, EType.Normal, null),
            ("Magikarp", 129, EType.Water, null),
            ("Gyarados", 130, EType.Water, EType.Flying),
            ("Lapras", 131, EType.Water, EType.Ice),
            ("Ditto", 132, EType.Normal, null),
            ("Eevee", 133, EType.Normal, null),
            ("Vaporeon", 134, EType.Water, null),
            ("Jolteon", 135, EType.Electric, null),
            ("Flareon", 136, EType.Fire, null),
            ("Porygon", 137, EType.Normal, null),
            ("Omanyte", 138, EType.Rock, EType.Water),
            ("Omastar", 139, EType.Rock, EType.Water),
            ("Kabuto", 140, EType.Rock, EType.Water),
            ("Kabutops", 141, EType.Rock, EType.Water),
            ("Aerodactyl", 142, EType.Rock, EType.Flying),
            ("Snorlax", 143, EType.Normal, null),
            ("Articuno", 144, EType.Ice, EType.Flying),
            ("Zapdos", 145, EType.Electric, EType.Flying),
            ("Moltres", 146, EType.Fire, EType.Flying),
            ("Dratini", 147, EType.Dragon, null),
            ("Dragonair", 148, EType.Dragon, null),
            ("Dragonite", 149, EType.Dragon, EType.Flying),
            ("Mewtwo", 150, EType.Psychic, null),
            ("Mew", 151, EType.Psychic, null)
        };

        var pokemonList = pokemons.Select(p => new Pokemon
        {
            Name = p.Name,
            PokedexId = p.PokedexId,
            TypeOne = (RandomPokemon.Domain.Enums.EType)p.TypeOne,
            TypeTwo = (RandomPokemon.Domain.Enums.EType?)p.TypeTwo,
            Image = File.ReadAllBytes(Path.Combine(basePath, $"{p.PokedexId:D4} {p.Name}.png")),
            Silhouette = File.ReadAllBytes(Path.Combine(basePath, $"{p.PokedexId}.png")),
            Evolutions = new List<Pokemon>()
        }).ToList();

        await context.Pokemons.AddRangeAsync(pokemonList);
        await context.SaveChangesAsync();

        // Configurar evoluções
        var evolutions = new[]
        {
            (1, 2),   // Bulbasaur -> Ivysaur
            (2, 3),   // Ivysaur -> Venusaur
            (4, 5),   // Charmander -> Charmeleon
            (5, 6),   // Charmeleon -> Charizard
            (7, 8),   // Squirtle -> Wartortle
            (8, 9),   // Wartortle -> Blastoise
            (10, 11), // Caterpie -> Metapod
            (11, 12), // Metapod -> Butterfree
            (13, 14), // Weedle -> Kakuna
            (14, 15), // Kakuna -> Beedrill
            (16, 17), // Pidgey -> Pidgeotto
            (17, 18), // Pidgeotto -> Pidgeot
            (19, 20), // Rattata -> Raticate
            (21, 22), // Spearow -> Fearow
            (23, 24), // Ekans -> Arbok
            (25, 26), // Pikachu -> Raichu
            (27, 28), // Sandshrew -> Sandslash
            (29, 30), // Nidoran♀ -> Nidorina
            (30, 31), // Nidorina -> Nidoqueen
            (32, 33), // Nidoran♂ -> Nidorino
            (33, 34), // Nidorino -> Nidoking
            (35, 36), // Clefairy -> Clefable
            (37, 38), // Vulpix -> Ninetales
            (39, 40), // Jigglypuff -> Wigglytuff
            (41, 42), // Zubat -> Golbat
            (43, 44), // Oddish -> Gloom
            (44, 45), // Gloom -> Vileplume
            (46, 47), // Paras -> Parasect
            (48, 49), // Venonat -> Venomoth
            (50, 51), // Diglett -> Dugtrio
            (52, 53), // Meowth -> Persian
            (54, 55), // Psyduck -> Golduck
            (56, 57), // Mankey -> Primeape
            (58, 59), // Growlithe -> Arcanine
            (60, 61), // Poliwag -> Poliwhirl
            (61, 62), // Poliwhirl -> Poliwrath
            (63, 64), // Abra -> Kadabra
            (64, 65), // Kadabra -> Alakazam
            (66, 67), // Machop -> Machoke
            (67, 68), // Machoke -> Machamp
            (69, 70), // Bellsprout -> Weepinbell
            (70, 71), // Weepinbell -> Victreebel
            (72, 73), // Tentacool -> Tentacruel
            (74, 75), // Geodude -> Graveler
            (75, 76), // Graveler -> Golem
            (77, 78), // Ponyta -> Rapidash
            (79, 80), // Slowpoke -> Slowbro
            (81, 82), // Magnemite -> Magneton
            (84, 85), // Doduo -> Dodrio
            (86, 87), // Seel -> Dewgong
            (88, 89), // Grimer -> Muk
            (90, 91), // Shellder -> Cloyster
            (92, 93), // Gastly -> Haunter
            (93, 94), // Haunter -> Gengar
            (96, 97), // Drowzee -> Hypno
            (98, 99), // Krabby -> Kingler
            (100, 101), // Voltorb -> Electrode
            (102, 103), // Exeggcute -> Exeggutor
            (104, 105), // Cubone -> Marowak
            (109, 110), // Koffing -> Weezing
            (111, 112), // Rhyhorn -> Rhydon
            (118, 119), // Goldeen -> Seaking
            (120, 121), // Staryu -> Starmie
            (129, 130), // Magikarp -> Gyarados
            (133, 134), // Eevee -> Vaporeon
            (133, 135), // Eevee -> Jolteon
            (133, 136), // Eevee -> Flareon
            (138, 139), // Omanyte -> Omastar
            (140, 141), // Kabuto -> Kabutops
            (147, 148), // Dratini -> Dragonair
            (148, 149), // Dragonair -> Dragonite
        };

        foreach (var evolution in evolutions)
        {
            var fromPokemon = pokemonList.First(p => p.PokedexId == evolution.Item1);
            var toPokemon = pokemonList.First(p => p.PokedexId == evolution.Item2);
            fromPokemon.Evolutions.Add(toPokemon);
        }

        await context.SaveChangesAsync();
    }
}

public enum EType
{
    Normal = 0,
    Fire = 1,
    Water = 2,
    Grass = 3,
    Electric = 4,
    Ice = 5,
    Fighting = 6,
    Poison = 7,
    Ground = 8,
    Flying = 9,
    Psychic = 10,
    Bug = 11,
    Rock = 12,
    Ghost = 13,
    Dragon = 14,
    Steel = 15,
    Fairy = 16
}