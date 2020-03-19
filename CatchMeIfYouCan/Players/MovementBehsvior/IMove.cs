using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatchMeIfYouCanImproved;
namespace CatchMeIfYouCanImproved.Players.MovementBehsvior
{
    public interface IMove
    {
        void Move(Figure figure, ConsoleKey key);
    }
}
