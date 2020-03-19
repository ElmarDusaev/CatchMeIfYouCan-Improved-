using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchMeIfYouCanImproved.Players.MovementBehsvior
{

    [Serializable]
    class Player1Move : IMove
    {
        public void Move(Figure figure, ConsoleKey key)
        {
            if (figure.X == 1 && figure.Y == 3)
            {
                figure.Y--;
            }

            else if (figure.X == 1 && figure.Y == 0)
            {
                figure.Y++;
            }
            else figure.X--;
        }
    }
}
