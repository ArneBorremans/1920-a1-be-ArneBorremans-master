using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.Models
{
    public class TribeOD
    {
        #region Properties
        public int World { get; set; }
        public int ID { get; set; }
        public long Tribe_Id { get; set; }
        public long OD { get; set; }
        public long OD_Rank { get; set; }
        public long ODA { get; set; }
        public long ODA_Rank { get; set; }
        public long ODD { get; set; }
        public long ODD_Rank { get; set; }
        #endregion

        #region Constructors
        public TribeOD()
        {

        }
        #endregion
    }
}
