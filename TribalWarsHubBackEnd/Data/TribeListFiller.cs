using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class TribeListFiller
    {
        public static void FillTribeRepository(ApplicationDbContext dbContext, int[] worlds)
        {
            foreach (var world in worlds)
            {
                Console.WriteLine("Loading tribes " + world + "...");


                var currentDirectory = Directory.GetCurrentDirectory();
                var pathFiles = Path.Combine(currentDirectory, "Data", "Files", world.ToString(), "tribes");

                List<Tribe> tribes = File.ReadAllLines(pathFiles)
                    .Select(v => FromCsv(v, world))
                    .ToList();
                using (var transaction = dbContext.Database.BeginTransaction())
                {

                    foreach (Tribe tribe in tribes)
                    {
                        dbContext.Tribes.Add(tribe);
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                Console.WriteLine("Tribes loaded " + world);
            }
        }
        public static Tribe FromCsv(string csvLine, int world)
        {
            string[] values = csvLine.Split(",");
            Tribe tribe = new Tribe();
            tribe.World = world;
            tribe.Tribe_Id = Convert.ToInt32(values[0]);
            tribe.Name = String.Format(Convert.ToString(values[1]));
            tribe.Tag = String.Format(Convert.ToString(values[2]));
            tribe.MemberCount = Convert.ToInt32(values[3]);
            tribe.VillageCount = Convert.ToInt32(values[4]);
            tribe.Points = Convert.ToInt32(values[5]);
            tribe.AllPoints = Convert.ToInt32(values[6]);
            tribe.Rank = Convert.ToInt32(values[7]);
            return tribe;
        }
    }
}
