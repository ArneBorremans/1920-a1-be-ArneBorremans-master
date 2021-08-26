namespace TribalWarsHubBackEnd.Models
{
    public class CustomerFavorite
    {
        #region Properties
        public int CustomerId { get; set; }

        public int CommentId { get; set; }

        public Customer Customer { get; set; }

        public Comment Comment { get; set; }
        #endregion
    }
}
