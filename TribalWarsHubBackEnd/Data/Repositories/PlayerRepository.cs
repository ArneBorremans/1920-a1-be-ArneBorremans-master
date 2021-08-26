using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Player> _players;

        public PlayerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _players = dbContext.Players;
        }

        public IEnumerable<Player> GetAll(int world)
        {
            return _players.Where(r => r.World == world).ToList();
        }

        public Player GetBy(int world, int player_Id)
        {
            return _players.SingleOrDefault(r => r.Player_Id == player_Id && r.World == world);
        }

        public Player GetByRank(int world, int rank)
        {
            return _players.FirstOrDefault(r => r.Rank == rank && r.World == world);
        }

        public bool TryGetPlayer(int player_Id, out Player player)
        {
            player = _context.Players.FirstOrDefault(t => t.Player_Id == player_Id);
            return player != null;
        }

        public void Add(Player player)
        {
            _players.Add(player);
        }

        public void Update(Player player)
        {
            _players.Update(player);
        }

        public void Delete(Player player)
        {
            _players.Remove(player);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
