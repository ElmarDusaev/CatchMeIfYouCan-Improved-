using CatchMeIfYouCanImproved.Canvases;
using CatchMeIfYouCanImproved.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatchMeIfYouCanImproved.Games
{
    class MultiGame:Game
    {

        string path = "";

        public MultiGame()
        {
            Console.Clear();
            Console.WriteLine("Укажите, пожлуйста, общую папку:");
            path = Console.ReadLine() + @"\temp.dat";
            Console.WriteLine("Общая папка " + path);
        }

    }
}
