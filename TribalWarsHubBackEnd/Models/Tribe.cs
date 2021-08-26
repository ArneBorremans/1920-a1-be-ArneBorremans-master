using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public class Tribe
    {
        #region Properties
        public int World { get; set; }
        public int ID { get; set; }
        public int Tribe_Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int MemberCount { get; set; }
        public int VillageCount { get; set; }
        public int Points { get; set; }
        public int AllPoints { get; set; }
        public int Rank { get; set; }
        #endregion

        #region Constructors
        public Tribe()
        {

        }
        #endregion

        public override string ToString()
        {
            return String.Format($"Tribe: {Name} Rank: {Rank} Points: {Points} Villages: {VillageCount}");
        }
    }
}
