using BlankApp1.Infra.Distant.Interfaces;
using Entities;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Infra.Distant.Implementations
{
    class SwapiAPI
    {
        public string swapiUrl = "https://swapi.dev/api";
        public async Task<List<StarWarsCharacter>> GetAllStarWarsCharactersAsync()
        {
            var handler = new HttpClientHandler
            {
                UseProxy = false
            };
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://swapi.dev/api")
            };
            var test = 1;
            var swapiService = RestService.For<ISwapiAPI>(client);
            var test3 = 2;
            JObject result = await swapiService.GetAllStarWarsCharacters();
            var test2 = 1;
            return result["results"].ToObject<List<StarWarsCharacter>>();
        }
    }
}
