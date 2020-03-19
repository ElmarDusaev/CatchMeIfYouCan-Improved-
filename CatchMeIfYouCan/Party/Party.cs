using CatchMeIfYouCanImproved.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchMeIfYouCanImproved
{
    [Serializable]
    public class Party
    {
        public PlayerTurn PlayerTurn { get; set; }
        public ConsoleKey Key { get; set; }
        public Player1 Player1 { get; set; }
        public Player2 Player2 { get; set; }

    }



}
