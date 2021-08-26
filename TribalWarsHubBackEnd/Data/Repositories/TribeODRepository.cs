using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class TribeODRepository : ITribeODRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TribeOD> _tribeODs;

        public TribeODRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _tribeODs = dbContext.TribeODs;
        }

        public IEnumerable<TribeOD> GetAll()
        {
            return _tribeODs.ToList();
        }

        public TribeOD GetById(int world, int tribe_id)
        {
            return _tribeODs.SingleOrDefault(r => r.Tribe_Id == tribe_id && r.World == world);
        }

        public void Add(TribeOD tribeOD)
        {
            _tribeODs.Add(tribeOD);
        }

        public void Update(TribeOD tribeOD)
        {
            _tribeODs.Update(tribeOD);
        }

        public void Delete(TribeOD tribeOD)
        {
            _tribeODs.Remove(tribeOD);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
