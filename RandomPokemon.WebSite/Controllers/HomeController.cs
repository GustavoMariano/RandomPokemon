using Microsoft.AspNetCore.Mvc;
using RandomPokemon.WebSite.Models;
using System.Diagnostics;
using System.Text.Json;

namespace RandomPokemon.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        const string urlApi = "https://localhost:7063/randompokemon";

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllPokemons()
        {
            try
            {
                var response = await _httpClient.GetAsync(urlApi + "/all");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var pokemons = JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
                    return View(pokemons);
                }
                else
                {
                    ViewData["ErrorMessage"] = "Could not load Pokémon list.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        public IActionResult GuessPokemon()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomPokemon()
        {
            try
            {
                var response = await _httpClient.GetAsync(urlApi + "/random");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var pokemon = JsonSerializer.Deserialize<Pokemon>(content);

                return Json(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Failed to fetch Pokémon data: " + ex.Message });
            }
        }

        public IActionResult ViewPokemon()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPokemonByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewData["Error"] = "Please enter a Pokémon name.";
                return View("ViewPokemon", new Pokemon());
            }

            try
            {
                var response = await _httpClient.GetAsync($"{urlApi}/byPokemonName?name={Uri.EscapeDataString(name)}");

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent || !response.IsSuccessStatusCode)
                {
                    ViewData["Error"] = $"Pokémon '{name}' not found. Please enter a valid Pokémon name.";
                    return View("ViewPokemon", new Pokemon());
                }

                var content = await response.Content.ReadAsStringAsync();
                var pokemon = JsonSerializer.Deserialize<Pokemon>(content);

                if (pokemon == null || string.IsNullOrEmpty(pokemon.Name))
                {
                    ViewData["Error"] = $"Pokémon '{name}' not found. Please enter a valid Pokémon name.";
                    return View("ViewPokemon", new Pokemon());
                }

                return View("ViewPokemon", pokemon);
            }
            catch (HttpRequestException)
            {
                ViewData["Error"] = "Pokémon not found.";
                return View("ViewPokemon", new Pokemon());
            }
            catch (JsonException)
            {
                ViewData["Error"] = $"Invalid response from the API for Pokémon '{name}'. Please try again.";
                return View("ViewPokemon", new Pokemon());
            }
            catch (Exception ex)
            {
                ViewData["Error"] = $"Failed to fetch Pokémon data: {ex.Message}";
                return View("ViewPokemon", new Pokemon());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}