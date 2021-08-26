using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TribalWarsHubBackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class TWMapRepository : ITWMapRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TWMap> _tWMaps;

        public TWMapRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _tWMaps = dbContext.TWMaps;
        }

        public IEnumerable<TWMap> GetAll()
        {
            return _tWMaps.ToList();
        }

        public TWMap GetBy(int id)
        {
            return _tWMaps.SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetTWMap(int id, out TWMap tWMap)
        {
            tWMap = _context.TWMaps.FirstOrDefault(t => t.Id == id);
            return tWMap != null;
        }

        public void Add(TWMap tWMap)
        {
            _tWMaps.Add(tWMap);
        }

        public void Update(TWMap tWMap)
        {
            _tWMaps.Update(tWMap);
        }

        public void Delete(TWMap tWMap)
        {
            _tWMaps.Remove(tWMap);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
