using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public class Player
    {
        #region Properties
        public int World { get; set; }
        public int ID { get; set; }
        public int Player_Id { get; set; }
        public string Name { get; set; }
        public int Tribe_Id { get; set; }
        public int VillageCount { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        #endregion

        #region Constructors
        public Player(int player_Id, string name, int tribe_Id, int villageCount, int points, int rank)
        {
            Player_Id = player_Id;
            Name = name;
            Tribe_Id = tribe_Id;
            VillageCount = villageCount;
            Points = points;
            Rank = rank;
        }

        public Player()
        {

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format($"Player: {Name} Rank: {Rank} Points: {Points} Villages: {VillageCount}");
        }
        #endregion
    }
}
