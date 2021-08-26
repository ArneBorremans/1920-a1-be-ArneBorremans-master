using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public class PlayerOD
    {
        #region Properties
        public int World { get; set; }
        public int ID { get; set; }
        public int Player_Id { get; set; }
        public int OD { get; set; }
        public int OD_Rank { get; set; }
        public int ODA { get; set; }
        public int ODA_Rank { get; set; }
        public int ODD { get; set; }
        public int ODD_Rank { get; set; }
        #endregion

        #region Constructors
        public PlayerOD()
        {

        }
        #endregion
    }
}
