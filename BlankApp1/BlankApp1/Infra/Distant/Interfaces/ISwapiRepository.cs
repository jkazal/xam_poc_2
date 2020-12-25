using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Infra.Distant.Interfaces
{
    public interface ISwapiRepository
    {
        Task<List<StarWarsCharacter>> GetAllStarWarsCharactersAsync();
    }
}
