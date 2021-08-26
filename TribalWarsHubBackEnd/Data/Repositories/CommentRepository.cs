using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Comment> _comments;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _comments = dbContext.Comments;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _comments.ToList();
        }

        public Comment GetBy(int comment_Id)
        {
            return _comments.SingleOrDefault(r => r.Comment_Id == comment_Id);
        }

        public void Add(Comment comment)
        {
            _comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            _comments.Update(comment);
        }

        public void Delete(Comment comment)
        {
            _comments.Remove(comment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
