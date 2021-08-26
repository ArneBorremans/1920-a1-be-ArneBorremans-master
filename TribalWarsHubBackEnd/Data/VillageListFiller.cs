using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class VillageListFiller
    {
        public static void FillVillageRepository(ApplicationDbContext dbContext, int[] worlds)
        {
            foreach (var world in worlds)
            {
                Console.WriteLine("Loading villages " + world + "...");

                var currentDirectory = Directory.GetCurrentDirectory();
                var pathFiles = Path.Combine(currentDirectory, "Data", "Files", world.ToString(), "villages");

                List<Village> villages = File.ReadAllLines(pathFiles)
                    .Select(v => FromCsv(v, world))
                    .ToList();
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    int numberOfVills = 1;
                    foreach (Village village in villages)
                    {
                        dbContext.Villages.Add(village);
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                Console.WriteLine("Villages loaded " + world);
            }
        }

        public static Village FromCsv(string csvLine, int world)
        {
            string[] values = csvLine.Split(",");
            Village village = new Village();
            village.World = world;
            village.Village_Id = Convert.ToInt32(values[0]);
            village.Name = Convert.ToString(values[1]);
            village.x = Convert.ToInt32(values[2]);
            village.y = Convert.ToInt32(values[3]);
            village.Player_Id = Convert.ToInt32(values[4]);
            village.Points = Convert.ToInt32(values[5]);
            village.Rank = Convert.ToInt32(values[6]);
            return village;
        }
    }
}
