using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Models
{
    public interface IPlayerRepository
    {
        Player GetBy(int world, int player_id);
        Player GetByRank(int world, int rank);
        bool TryGetPlayer(int player_id, out Player player);
        IEnumerable<Player> GetAll(int world);
        void Add(Player player);
        void Delete(Player player);
        void Update(Player player);
        void SaveChanges();
    }
}
