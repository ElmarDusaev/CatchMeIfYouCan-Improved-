using CatchMeIfYouCanImproved.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// Catch Me If You Can
    /// Created By Elmar Dusaev


namespace CatchMeIfYouCanImproved
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Menu menu = new Menu();
            menu.ShowMenu();

            Console.Read();
        }
    }
}
