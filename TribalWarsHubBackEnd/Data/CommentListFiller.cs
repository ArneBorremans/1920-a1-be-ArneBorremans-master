using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class CommentListFiller
    {
        public static void FillCommentRepository(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Loading comments...");

            var currentDirectory = Directory.GetCurrentDirectory();
            var pathFiles = Path.Combine(currentDirectory, "Data", "Files", "comments");

            List<Comment> comments = File.ReadAllLines(pathFiles)
                .Select(v => FromCsv(v))
                .ToList();
            
            if(comments.Count() > 0)
                comments.Sort((x, y) => x.Comment_Id - y.Comment_Id);

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Comments] ON");

                foreach (Comment comment in comments)
                {
                    dbContext.Comments.Add(comment);
                }
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Comments] OFF");
                transaction.Commit();
            }
            Console.WriteLine("Comments loaded");
        }

        public static void UpdateCommentRepository(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Updating comments...");
            // Make path relative!
            List<Comment> comments = File.ReadAllLines("C:\\Users\\Arne\\source\\repos\\TribalWarsHubBackEnd\\TribalWarsHubBackEnd\\Data\\Files\\comments")
                .Select(v => FromCsv(v))
                .ToList();

            if (comments.Count() > 0)
                comments.Sort((x, y) => x.Comment_Id - y.Comment_Id);

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Comments] ON");

                foreach (Comment comment in comments)
                {
                    dbContext.Comments.Update(comment);
                }
                dbContext.SaveChanges();
                dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Comments] OFF");
                transaction.Commit();
            }
            Console.WriteLine("Comments updated");
        }

        public static Comment FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",");
            Comment comment = new Comment();
            comment.Comment_Id = Convert.ToInt32(values[0]);
            comment.Writer = values[1];
            comment.Content = values[2];
            comment.Date = values[3];
            return comment;
        }

        public static void addToCsv(Comment comment) {
            var csv = new StringBuilder();

            var id_temp = comment.Comment_Id;
            var writer_temp = comment.Writer;
            var content_temp = comment.Content;
            var date_temp = comment.Date;

            var newLine = $"{id_temp},{writer_temp},{content_temp},{date_temp}";

            csv.AppendLine(newLine);

            var currentDirectory = Directory.GetCurrentDirectory();
            var pathFiles = Path.Combine(currentDirectory, "Data", "Files", "comments");

            File.AppendAllText(pathFiles, csv.ToString());
        }

        public static async Task deleteFromCsv(Comment comment)
        {
            List<Comment> linesList = File.ReadAllLines("C:\\Users\\Arne\\source\\repos\\TribalWarsHubBackEnd\\TribalWarsHubBackEnd\\Data\\Files\\comments")
                .Select(v => FromCsv(v)).ToList();

            linesList.Sort((x, y) => x.Comment_Id - y.Comment_Id);

            int index = linesList
                .ToList()
                .FindIndex(t => t.Comment_Id == comment.Comment_Id);

            linesList.RemoveAt(index);
            File.WriteAllText("C:\\Users\\Arne\\source\\repos\\TribalWarsHubBackEnd\\TribalWarsHubBackEnd\\Data\\Files\\comments", string.Empty);

            foreach(Comment localComment in linesList)
            {
                if(localComment != null)
                    addToCsv(localComment);
            }
        }
    }
}
