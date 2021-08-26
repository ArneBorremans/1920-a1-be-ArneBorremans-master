using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public interface IPlayerODRepository
    {
        PlayerOD GetById(int world, int player_id);
        IEnumerable<PlayerOD> GetAll();
        void Add(PlayerOD playerOD);
        void Delete(PlayerOD playerOD);
        void Update(PlayerOD playerOD);
        void SaveChanges();
    }
}
