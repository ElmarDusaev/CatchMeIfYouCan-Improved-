using CatchMeIfYouCanImproved.Players.MovementBehsvior;
using System;
using System.Linq;

namespace CatchMeIfYouCanImproved.Players
{
    [Serializable]
    public class Player1 : Player
    {
        public Player1()
        {
            Name = "Player 1";
            iMove = new Player1Move();
            Figures = new Figure[] {new Figure{ X = 3, Y = 0 }, new Figure{ X = 4, Y = 1 }, new Figure{ X = 3, Y = 2 }};
        }

        public override Figure GetFigure(ConsoleKey key)
        {
            Figure _figure = null;
            switch (key)
            {
                case ConsoleKey.NumPad1:
                    _figure = Figures[0];
                    break;
                case ConsoleKey.NumPad2:
                    _figure = Figures[1];
                    break;
                case ConsoleKey.NumPad3:
                    _figure = Figures[2];
                    break;
            }
            return _figure;
        }


    }
}
