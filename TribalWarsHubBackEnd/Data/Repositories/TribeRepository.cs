using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class TribeRepository : ITribeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Tribe> _tribes;

        public TribeRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _tribes = dbContext.Tribes;
        }

        public IEnumerable<Tribe> GetAll(int world)
        {
            return _tribes.Where(r => r.World == world).ToList();
        }

        public Tribe GetBy(int world, int tribe_Id)
        {
            return _tribes.SingleOrDefault(r => r.Tribe_Id == tribe_Id && r.World == world);
        }

        public Tribe GetByRank(int world, int rank)
        {
            return _tribes.SingleOrDefault(r => r.Rank == rank && r.World == world);
        }

        public bool TryGetTribe(int tribe_Id, out Tribe tribe)
        {
            tribe = _context.Tribes.FirstOrDefault(t => t.Tribe_Id == tribe_Id);
            return tribe != null;
        }

        public void Add(Tribe tribe)
        {
            _tribes.Add(tribe);
        }

        public void Update(Tribe tribe)
        {
            _tribes.Update(tribe);
        }

        public void Delete(Tribe tribe)
        {
            _tribes.Remove(tribe);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
