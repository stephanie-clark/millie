using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millie.Game
{
    public class GameState
    {
        public GameState()
        {
            BeardLength = 2;
        }

        // character attributes 
        public int BeardLength { get; set; }
        // TODO: Make sure beard length can't go above 5 or below 0. ALso starts at a 2.
       
        // BAR CAR EVENTS
        public bool AskedAboutFlowers { get; set; }
        public bool AskedAboutArmWrestling { get; set; }
        public bool HasFlowers { get; set; }
        public int NumberOfShotsTaken { get; set; }

        // TATOO ROOM EVENTS
        public bool DrankElixer { get; set; }
        public bool AskAboutTattoo { get; set; }
        public bool GotNeckTattoo { get; set; }
        public bool GotArmTattoo { get; set; }
        public bool GotTattoo { get; set; }
        public bool UsedHookah { get; set; }

        // MAIN TENT EVENTS
        public bool AskAboutGoats { get; set; }
        public bool ApproachGoats { get; set; }
        public bool GaveCompliment { get; set; }
        public bool GotShampoo { get; set; }



        // visited locations  
        public int CurrentRoomID { get; set; }
        public bool VisitedTattooRoom { get; set; }
        public bool VisitedBarCar { get; set; }
        public bool VisitedMainTent { get; set; }
        public bool VisitedTrapezeRoom { get; set; }

        public bool MadeFinalChoice { get; set; }

    }
}
