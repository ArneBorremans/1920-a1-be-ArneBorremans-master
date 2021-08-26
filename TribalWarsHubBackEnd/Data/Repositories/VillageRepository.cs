using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class VillageRepository : IVillageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Village> _villages;

        public VillageRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _villages = dbContext.Villages;
        }

        public void Add(Village village)
        {
            _villages.Add(village);
        }

        public void Delete(Village village)
        {
            _villages.Remove(village);
        }

        public IEnumerable<Village> GetAll()
        {
            return _villages.ToList();
        }

        public Village GetBy(int village_id)
        {
            return _villages.SingleOrDefault(r => r.Village_Id == village_id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool TryGetVillage(int village_id, out Village village)
        {
            village = _context.Villages.FirstOrDefault(t => t.Village_Id == village_id);
            return village != null;
        }

        public void Update(Village village) { 
            _villages.Update(village);
        }
    }
}
