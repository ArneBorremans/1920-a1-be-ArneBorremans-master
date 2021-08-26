using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using TribalWarsHubBackEnd.Models;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using TribalWarsHubBackEnd.ScheduledTasks;

namespace TribalWarsHubBackEnd.Data
{
    public class DataInitializer
    {
        //private readonly TWMapContext _tWMapContext;
        //private readonly PlayerContext _playerContext;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;

            UpdateFiles();

            Task.Run(() => InitializeData()).Wait();
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                int[] worlds = new int[] { 107, 110, 111, 112, 113, 114};
                // initialize all data from csv files
                PlayerListFiller.FillPlayerRepository(this._dbContext, worlds);
                PlayerODListFiller.FillPlayerODRepository(this._dbContext, worlds);
                TribeListFiller.FillTribeRepository(this._dbContext, worlds);
                TribeODListFiller.FillTribeODRepository(this._dbContext, worlds);
                //VillageListFiller.FillVillageRepository(this._dbContext, worlds);

                CommentListFiller.FillCommentRepository(this._dbContext);

                //initialize users
                Customer customer = new Customer { Email = "commentmaster@hogent.be", FirstName = "Adam", LastName = "Master" };
                _dbContext.Customers.Add(customer);
                Console.WriteLine(customer.ToString() + "added");
                await CreateUser(customer.Email, "P@ssword1111");
                Console.WriteLine(customer.ToString() + "password added");
                Customer student = new Customer { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
                _dbContext.Customers.Add(student);
                Console.WriteLine(customer.ToString() + "added");
                student.AddFavoriteComment(_dbContext.Comments.First());
                await CreateUser(student.Email, "P@ssword1111");
                Console.WriteLine(customer.ToString() + "password added");

                //initialize maps
                _dbContext.TWMaps.Add(new TWMap {Name = "Top Tribes W111", Created = DateTime.Now });
                _dbContext.TWMaps.Add(new TWMap {Name = "Top Players W111", Created = DateTime.Now });
                _dbContext.TWMaps.Add(new TWMap {Name = "Recent Conquers W111", Created = DateTime.Now });

                _dbContext.SaveChanges();
            }
        }

        public static void UpdateFiles()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var pathFiles = Path.Combine(currentDirectory, "Data", "Files", "111");

            var lastUpdatedFiles = File.GetLastWriteTime(Path.Combine(pathFiles, "players"));
            Console.WriteLine($"Files last updated at: {lastUpdatedFiles}");

            // De files updaten op de source elk uur, dus kijken we of het al langer geleden is dan dat, dat ze geüpdate zijn geweest
            if (lastUpdatedFiles < DateTime.Now.Subtract(new TimeSpan(1, 0, 0)))
            {
                downloadFilesPerWorld("107");
                downloadFilesPerWorld("110");
                downloadFilesPerWorld("111");
                downloadFilesPerWorld("112");
                downloadFilesPerWorld("113");
                downloadFilesPerWorld("114");
            }
        }

        public static void downloadFilesPerWorld(String world)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var pathFiles = Path.Combine(currentDirectory, "Data", "Files", world);

            Console.Write("Updating Files" + world);
            downloadFile("https://en" + world + ".tribalwars.net/map/village.txt", Path.Combine(pathFiles, "villages"));
            downloadFile("https://en" + world + ".tribalwars.net/map/player.txt", Path.Combine(pathFiles, "players"));
            Console.Write(".");
            downloadFile("https://en" + world + ".tribalwars.net/map/ally.txt", Path.Combine(pathFiles, "tribes"));
            downloadFile("https://en" + world + ".tribalwars.net/map/conquer.txt", Path.Combine(pathFiles, "conquerHistory"));
            downloadFile("https://en" + world + ".tribalwars.net/map/kill_all.txt", Path.Combine(pathFiles, "OD"));
            Console.Write(".");
            downloadFile("https://en" + world + ".tribalwars.net/map/kill_att.txt", Path.Combine(pathFiles, "ODA"));
            downloadFile("https://en" + world + ".tribalwars.net/map/kill_def.txt", Path.Combine(pathFiles, "ODD"));
            downloadFile("https://en" + world + ".tribalwars.net/map/kill_all_tribe.txt", Path.Combine(pathFiles, "tribeOD"));
            Console.Write(".");
            Console.WriteLine();
            downloadFile("https://en" + world + ".tribalwars.net/map/kill_att_tribe.txt", Path.Combine(pathFiles, "tribeODA"));
            downloadFile("https://en" + world + ".tribalwars.net/map/kill_def_tribe.txt", Path.Combine(pathFiles, "tribeODD"));
            Console.WriteLine("Files Updated" + world);
        }

        public static void downloadFile(String url, String fileName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile($"{url}", @$"{fileName}");
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }

        public static async Task updatingFilesAndRepos()
        {
            UpdateFiles();
        }
    }
}
