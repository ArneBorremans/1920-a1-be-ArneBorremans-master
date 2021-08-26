using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public class Village
    {
        #region Properties
        public int World { get; set; }
        public int ID { get; set; }
        public int Village_Id { get; set; }
        public string Name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int Player_Id { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        #endregion

        #region Constructors
        public Village()
        {

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format($"Village: {Name} Coords: {x}|{y} Points: {Points} From Player ID: {Player_Id} Rank: {Rank}");
        }
        #endregion
    }
}
