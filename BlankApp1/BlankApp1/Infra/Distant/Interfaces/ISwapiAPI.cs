using Entities;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Infra.Distant.Interfaces
{
    public interface ISwapiAPI
    {
        [Get("/people/")]
        Task<JObject> GetAllStarWarsCharacters();
    }
}
