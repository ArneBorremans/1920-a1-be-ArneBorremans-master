using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class PlayerODListFiller
    {
        public static void FillPlayerODRepository(ApplicationDbContext dbContext, int[] worlds)
        {
            foreach (var world in worlds)
            {
                Console.WriteLine("Loading players OD's " + world + "...");

                var currentDirectory = Directory.GetCurrentDirectory();
                var pathFiles = Path.Combine(currentDirectory, "Data", "Files", world.ToString());

                List<int[]> OD = File.ReadAllLines(Path.Combine(pathFiles, "OD"))
                    .Select(v => FromCsv(v))
                    .ToList();
                List<int[]> ODA = File.ReadAllLines(Path.Combine(pathFiles, "ODA"))
                    .Select(v => FromCsv(v))
                    .ToList();
                List<int[]> ODD = File.ReadAllLines(Path.Combine(pathFiles, "ODD"))
                    .Select(v => FromCsv(v))
                    .ToList();

                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    foreach (int[] od in OD)
                    {
                        int id = (int)od.GetValue(1);

                        int odRank = (int)od.GetValue(0);
                        int odScore = (int)od.GetValue(2);
                        var odaArray = ODA.FirstOrDefault(x => (int)x.GetValue(1) == id);
                        var oddArray = ODD.FirstOrDefault(x => (int)x.GetValue(1) == id);

                        dbContext.PlayerODs.Add(new PlayerOD()
                        {
                            Player_Id = id,
                            World = world,
                            OD_Rank = odRank,
                            OD = odScore,
                            ODA_Rank = (odaArray == null ? 0 : odaArray[0]),
                            ODA = (odaArray == null ? 0 : odaArray[2]),
                            ODD_Rank = (oddArray == null ? 0 : oddArray[0]),
                            ODD = (oddArray == null ? 0 : oddArray[2])
                        });
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                Console.WriteLine("Players OD's loaded " + world);
            }
        }
        //$rank, $id, $score
        public static int[] FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",");
            int[] od = new int[3];
            od[0] = Convert.ToInt32(values[0]);
            od[1] = Convert.ToInt32(values[1]);
            od[2] = Convert.ToInt32(values[2]);
            return od;
        }
    }
}
