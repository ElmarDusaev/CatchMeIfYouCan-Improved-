using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatchMeIfYouCanImproved.Games
{
    class Menu
    {

        public Menu()
        {
            Splash();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tМеню игры");
                Console.WriteLine(new string('*', 25));
                Console.WriteLine();
                Console.WriteLine("\t1. Новая игра");
                Console.WriteLine("\t2. Проиграть сохраненную партию");
                //Console.WriteLine("\t3. Новая игра по сети (не реализовано)");
                Console.WriteLine("\t4. Выход");
                Console.WriteLine();
                Console.WriteLine(new string('*', 25));
                Console.Write("\tВыберите пункт меню:  ");

                var key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        new Game().Start();
                        break;

                    case "2":
                        new Game().PartyPlay();
                        break;

                    case "3":
                        new MultiGame().Start();
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }

            }
        }

        void Splash()
        {
            Console.Write(@"
██████████████──█████████████████──██
█────██────██─██─██─███──█────██─██─█
█─██─██─██─██─██─██──█───█─██─██─██─█
█─██─██─██─██─█──██─█─█──█────██─█──█
█─██─██─██─██──█─██─███──█─██─██──█─█
█─██─██────██─██─██─███──█─██─██─██─█
█████████████████████████████████████
███████████████████████████
█─███──█───██─██─██────████
█──█───█─████─██─██─██─████
█─█─█──█───██────██────████
█─███──█─████─██─███─█─██─█
█─███──█───██─██─███─█─██─█
███████████████████████████
███████████████████████
█───██────████──██─██─█
█─████─██─███─█─██─██─█
█───██─█████─██─██─█──█
█─████─██─██─██─██──█─█
█───██────██─██─██─██─█
███████████████████████
███████████████████████████████████████████████
█────██─███──█────██─█─█─██───██─███─██─█████─█
█─██─██──█───█─██─██─────██─████─███─██─█████─█
█─█████─█─█──█─██─███───███───██─█─█─██────██─█
█─██─██─███──█─██─██─────██─████─█─█─██─██─████
█────██─███──█────██─█─█─██───██─────██────██─█
███████████████████████████████████████████████");
            Thread.Sleep(3000);
            Console.Clear();
        }


    }
}
