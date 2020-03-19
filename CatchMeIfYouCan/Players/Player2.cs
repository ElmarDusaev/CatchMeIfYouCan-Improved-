using CatchMeIfYouCanImproved.Players.MovementBehsvior;
using System;
using System.Linq;
using CatchMeIfYouCanImproved.Players;
namespace CatchMeIfYouCanImproved.Players
{
    [Serializable]
    public class Player2 : Player
    {
        public Player2()
        {
            Name = "Player 2";
            iMove = new Player2Move();
            Figures = new Figure[]{new Figure { X = 2, Y = 1 } };
        }

        public override Figure GetFigure(ConsoleKey key)
        {
            return Figures[0];
        }

    }
}
