using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Models
{
    public interface ITWMapRepository
    {
        TWMap GetBy(int id);
        bool TryGetTWMap(int id, out TWMap tWMap);
        IEnumerable<TWMap> GetAll();
        void Add(TWMap tWMap);
        void Delete(TWMap tWMap);
        void Update(TWMap tWMap);
        void SaveChanges();
    }
}
