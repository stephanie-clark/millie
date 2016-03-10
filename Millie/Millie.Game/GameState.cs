using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class GameState
    {
        public int CurrentRoomID { get; set; }
        public int BeardLength { get; set; }    
        public bool VisitedTattooRoom { get; set; }



        public bool GotTattoo { get; set; }
    }
}
