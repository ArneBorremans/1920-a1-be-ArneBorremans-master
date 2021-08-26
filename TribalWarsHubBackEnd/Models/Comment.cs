using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public class Comment
    {
        #region Properties
        public int Comment_Id { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        #endregion

        #region Constructors
        public Comment()
        {

        }
        #endregion
    }
}
