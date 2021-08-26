using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Models
{
    public interface ITribeRepository
    {
        Tribe GetBy(int tribe_Id, int world);
        Tribe GetByRank(int world, int rank);
        bool TryGetTribe(int tribe_id, out Tribe tribe);
        IEnumerable<Tribe> GetAll(int world);
        void Add(Tribe tribe);
        void Delete(Tribe tribe);
        void Update(Tribe tribe);
        void SaveChanges();
    }
}
