using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using PokeApi.Models;

namespace PokeApi.Client
{
    public sealed class PokeClient : IPokeClient
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

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            //throw new NotImplementedException();
            // todo удалить перед выдачей задания
            var response = await this.httpClient.GetAsync($"pokemon/{id}");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pokemon>(content);
        }

        public async Task<PokemonList> GetPokemonsAsync(int? offset = null, int? limit = null)
        {
            //throw new NotImplementedException();
            // todo удалить перед выдачей задания
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (offset != null)
            {
                query["offset"] = $"{offset}";
            }

            if (limit != null)
            {
                query["limit"] = $"{limit}";
            }

            var response = await this.httpClient.GetAsync($"pokemon?{query}");

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PokemonList>(content);
        }
    }
}
