using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TribalWarsHubBackEnd.Models
{
    public class TWMap
    {
        #region Properties
        public int World { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; }
        #endregion

        #region Constructors
        public TWMap(/*string name*/)
        {
            Created = DateTime.Now;
            //Name = name;
        }
        #endregion

        #region Methods
        #endregion
    }
}
