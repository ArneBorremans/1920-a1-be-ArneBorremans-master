using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TribalWarsHubBackEnd.Data;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository context)
        {
            _commentRepository = context;
        }

        // GET: api/<controller>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Comment> GetComments()
        {
            return _commentRepository.GetAll().OrderBy(r => r.Date).Reverse();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Comment> GetById(int comment_Id)
        {
            Comment comment = _commentRepository.GetBy(comment_Id);
            if (comment == null) return NotFound();
            return comment;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Comment> PostComment(Comment comment)
        {
            if(comment.Writer != null && comment.Writer.Length > 0 && comment.Content != null && comment.Content.Length > 0)
            {
                Comment commentToCreate = new Comment() { Writer = comment.Writer, Content = comment.Content, Date = comment.Date };
                _commentRepository.Add(commentToCreate);
                _commentRepository.SaveChanges();

                CommentListFiller.addToCsv(commentToCreate);

                Console.WriteLine(_commentRepository.GetBy(commentToCreate.Comment_Id).Content);

                return CreatedAtAction(nameof(GetById), new { id = commentToCreate.Comment_Id }, commentToCreate);
            }
            return CreatedAtAction("", null);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("deleting" + id);

            Comment comment = _commentRepository.GetBy(id);

            _commentRepository.Delete(comment);
            _commentRepository.SaveChanges();
            Task.Run(() => CommentListFiller.deleteFromCsv(comment)).Wait();

            return NoContent();
        }
    }
}
