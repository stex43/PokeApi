using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using PokeApi.Models;

namespace PokeApi
{
    public sealed class PokeClient
    {
        private readonly HttpClient httpClient;

        public PokeClient()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://pokeapi.co/api/v2/")
            };
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            var response = await this.httpClient.GetAsync($"pokemon/{name}");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pokemon>(content);
        }

        public async Task<PokemonList> GetPokemonsAsync(int? offset = null, int? limit = null)
        {
            //throw new NotImplementedException();
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (offset != null)
            {
                query["offset"] = $"{offset}";
            }

            if (limit != null)
            {
                query["limit"] = $"{limit}";
            }

            var uriBuilder = new UriBuilder
            {
                Query = query.ToString()
            };

            var response = await this.httpClient.GetAsync($"pokemon?{uriBuilder}");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PokemonList>(content);
        }
    }
}
