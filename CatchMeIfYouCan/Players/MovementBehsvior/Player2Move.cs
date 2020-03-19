using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchMeIfYouCanImproved.Players.MovementBehsvior
{
    [Serializable]
    class Player2Move : IMove
    {
        public void Move(Figure figure, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (figure.X == 0 && figure.Y == 1)
                    {
                        figure.X++;
                        figure.Y = 0;
                    }
                    else
                        figure.Y--;
                    break;
                case ConsoleKey.RightArrow:
                    if (figure.X == 0 && figure.Y == 1)
                    {
                        figure.X++;
                        figure.Y = 2;
                    }
                    else figure.Y++;
                    break;
                case ConsoleKey.UpArrow:
                    figure.X--;
                    break;
                case ConsoleKey.DownArrow:
                    figure.X++;
                    break;
            }
        }
    }
}
