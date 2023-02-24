using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPI
{

    class Amiibo
    {
        [JsonProperty("gameSeries")]
        public string Game { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("tail")]
        public string Tail { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    class Data
    {
        [JsonProperty("amiibo")]
        public List<Amiibo> Amiibos { get; set; } = new();
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            await ProcessRepositories();

            static async Task ProcessRepositories()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter a Nintendo game character. Press Enter without writing a name to quit the program.");

                        var gameName = Console.ReadLine();

                        if (string.IsNullOrEmpty(gameName))
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }

                        var result = await client.GetAsync("https://www.amiiboapi.com/api/amiibo/?character=" + gameName.ToLower());
                        var resultRead = await result.Content.ReadAsStringAsync();

                        var amiibo = JsonConvert.DeserializeObject<Data>(resultRead).Amiibos.First();

                        Console.WriteLine("----");
                        Console.WriteLine("Character Name: " + amiibo.Character);
                        Console.WriteLine("Full Character(s) Name:  " + amiibo.Name);
                        Console.WriteLine("Game Series: " + amiibo.Game);
                        Console.WriteLine("Tail: " + amiibo.Tail);
                        Console.WriteLine("\n-----");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR. Please enter a valid character name!");
                    }
                }
            }
        }

        private static readonly HttpClient client = new HttpClient();

    }
}