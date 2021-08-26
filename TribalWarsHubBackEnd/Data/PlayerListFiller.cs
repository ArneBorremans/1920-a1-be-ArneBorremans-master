using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class PlayerListFiller
    {
        public static void FillPlayerRepository(ApplicationDbContext dbContext, int[] worlds)
        {
            foreach(var world in worlds)
            {
                Console.WriteLine("Loading players " + world + "...");

                var currentDirectory = Directory.GetCurrentDirectory();
                var pathFiles = Path.Combine(currentDirectory, "Data", "Files", world.ToString(), "players");


                List<Player> players = File.ReadAllLines(pathFiles)
                    .Select(v => FromCsv(v, world))
                    .ToList();
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    foreach (Player player in players)
                    {
                        dbContext.Players.Add(player);
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                Console.WriteLine("Players loaded " + world);
            }
        }

        public static Player FromCsv(string csvLine, int world)
        {
            string[] values = csvLine.Split(",");
            Player player = new Player();
            player.World = world;
            player.Player_Id = Convert.ToInt32(values[0]);
            player.Name = String.Format(Convert.ToString(values[1]));
            player.Tribe_Id = Convert.ToInt32(values[2]);
            player.VillageCount = Convert.ToInt32(values[3]);
            player.Points = Convert.ToInt32(values[4]);
            player.Rank = Convert.ToInt32(values[5]);
            return player;
        }
    }
}
