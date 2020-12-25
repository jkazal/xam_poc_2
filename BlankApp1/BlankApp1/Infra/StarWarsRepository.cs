using BlankApp1.Infra.Distant.Implementations;
using BlankApp1.Infra.Distant.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Infra
{
    class StarWarsRepository : ISwapiRepository
    {
        public SwapiAPI swapiAPIService;

        public StarWarsRepository ()
        {
            swapiAPIService = new SwapiAPI();
        }

        public async Task<List<StarWarsCharacter>> GetAllStarWarsCharactersAsync() 
        {
            return await swapiAPIService.GetAllStarWarsCharactersAsync();
        }
    }
}
