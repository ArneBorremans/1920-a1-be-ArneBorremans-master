using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Models
{
    public interface ICommentRepository
    {
        Comment GetBy(int comment_id);
        IEnumerable<Comment> GetAll();
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
        void SaveChanges();
    }
}
