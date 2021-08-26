using System.Collections.Generic;
using System.Linq;

namespace TribalWarsHubBackEnd.Models
{
    public class Customer
    {
        #region Properties
        //add extra properties if needed
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<CustomerFavorite> Favorites { get; private set; }

        public IEnumerable<Comment> FavoriteComments => Favorites.Select(f => f.Comment);
        #endregion

        #region Constructors
        public Customer()
        {
            Favorites = new List<CustomerFavorite>();
        }
        #endregion

        #region Methods
        public void AddFavoriteComment(Comment comment)
        {
            Favorites.Add(new CustomerFavorite() { CommentId = comment.Comment_Id, CustomerId = CustomerId, Comment = comment, Customer = this });
        }
        #endregion
    }
}

