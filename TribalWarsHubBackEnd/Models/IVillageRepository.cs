using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public interface IVillageRepository
    {
        Village GetBy(int village_id);
        bool TryGetVillage(int village_id, out Village village);
        IEnumerable<Village> GetAll();
        void Add(Village village);
        void Delete(Village village); 
        void Update(Village village);
        void SaveChanges();
    }
}
