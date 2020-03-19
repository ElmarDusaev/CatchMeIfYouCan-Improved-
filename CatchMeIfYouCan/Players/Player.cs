using CatchMeIfYouCanImproved.Players.MovementBehsvior;
using System;
using System.Linq;

namespace CatchMeIfYouCanImproved.Players
{
    [Serializable]
    public abstract class Player : ICloneable
    {
        string name;
        public string Name { get { return name; } protected set{ name = value; } }

        public Figure[] Figures { get; set; }

        protected IMove iMove;
        public abstract Figure GetFigure(ConsoleKey key);


        public void Move(ConsoleKey key)
        {
            var figure = GetFigure(key);
            if(figure !=null) iMove.Move(figure, key);
        }


        public object Clone()
        {
            var temp = (Player)MemberwiseClone();
            temp.Figures = Figures.Select(a => new Figure() { X = a.X, Y = a.Y }).ToArray();
            return temp;
        }

        public Figure this[int index]
        {
            get { return Figures[index]; }
            set { Figures[index] = value; }
        }



    }
}
