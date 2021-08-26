using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class PlayerODRepository : IPlayerODRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<PlayerOD> _playerODs;

        public PlayerODRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _playerODs = dbContext.PlayerODs;
        }

        public IEnumerable<PlayerOD> GetAll()
        {
            return _playerODs.ToList();
        }

        public PlayerOD GetById(int world, int player_id)
        {
            return _playerODs.SingleOrDefault(r => r.Player_Id == player_id && r.World == world);
        }

        public void Add(PlayerOD playerOD)
        {
            _playerODs.Add(playerOD);
        }

        public void Update(PlayerOD playerOD)
        {
            _playerODs.Update(playerOD);
        }

        public void Delete(PlayerOD playerOD)
        {
            _playerODs.Remove(playerOD);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
