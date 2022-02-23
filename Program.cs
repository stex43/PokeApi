using System.Threading.Tasks;

namespace PokeApi
{
    public sealed class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new PokeClient();

            var pokemon = await client.GetPokemonAsync("magnemite");

            var pokemons = await client.GetPokemonsAsync();
        }
    }
}
