using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class GameState
    {
     
        // character attributes 
        public int BeardLength { get; set; }
        public int NumberOfShotsTaken { get; set; }
        public bool GotTattoo { get; set; }
        public bool HasFlowers { get; set; }

        // visited locations  
        public int CurrentRoomID { get; set; }
        public bool VisitedTattooRoom { get; set; }
        public bool VisitedBarCar { get; set; }
        public bool VisitedLionTent { get; set; }

    }
}
