using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class TribeODListFiller
    {
        public static void FillTribeODRepository(ApplicationDbContext dbContext, int[] worlds)
        {
            foreach (var world in worlds)
            {
                Console.WriteLine("Loading tribes OD's " + world + "...");

                var currentDirectory = Directory.GetCurrentDirectory();
                var pathFiles = Path.Combine(currentDirectory, "Data", "Files", world.ToString());

                List<long[]> OD = File.ReadAllLines(Path.Combine(pathFiles, "tribeOD"))
                    .Select(v => FromCsv(v))
                    .ToList();
                List<long[]> ODA = File.ReadAllLines(Path.Combine(pathFiles, "tribeODA"))
                    .Select(v => FromCsv(v))
                    .ToList();
                List<long[]> ODD = File.ReadAllLines(Path.Combine(pathFiles, "tribeODD"))
                    .Select(v => FromCsv(v))
                    .ToList();

                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    foreach (long[] od in OD)
                    {
                        long id = (long)od.GetValue(1);

                        long odRank = (long)od.GetValue(0);
                        long odScore = (long)od.GetValue(2);
                        var odaArray = ODA.FirstOrDefault(x => (long)x.GetValue(1) == id);
                        var oddArray = ODD.FirstOrDefault(x => (long)x.GetValue(1) == id);

                        dbContext.TribeODs.Add(new TribeOD()
                        {
                            Tribe_Id = id,
                            World = world,
                            OD_Rank = odRank,
                            OD = odScore,
                            ODA_Rank = (int) (odaArray == null ? 0 : odaArray[0]),
                            ODA = (odaArray == null ? 0 : odaArray[2]),
                            ODD_Rank = (int) (oddArray == null ? 0 : oddArray[0]),
                            ODD = (oddArray == null ? 0 : oddArray[2])
                        });
                    }
                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                Console.WriteLine("Tribe OD's loaded " + world);
            }
        }
        //$rank, $id, $score
        public static long[] FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",");
            long[] od = new long[3];
            od[0] = Convert.ToInt64(values[0]);
            od[1] = Convert.ToInt64(values[1]);
            od[2] = Convert.ToInt64(values[2]);
            return od;
        }
    }
}
