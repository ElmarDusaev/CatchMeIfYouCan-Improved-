using CatchMeIfYouCanImproved.Canvases;
using CatchMeIfYouCanImproved.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace CatchMeIfYouCanImproved.Games
{
    class Game
    {
        bool Status;
        Player CurrentPlayer;

        Player1 player1;
        Player2 player2;
        PlayerTurn PlayerTurn;
        PartyPlayer partyPlayer;

        public Game()
        {
            Reset();
        }


        public void Start()
        {
            NewGame();
        }

        void NewGame()
        {
            Reset();
            while (Status)
            {
                Draw();
                KeyPress();
            }
        }

        internal void PartyPlay()
        {
            Clear();

            string name = "";
            var result = ReadPartyes(out name);
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.Clear();
                    Console.WriteLine(new string('*', 25));
                    Console.WriteLine();
                    Canvas.SetPoints(item.Player1, item.Player2);
                    Canvas.Draw();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(new string('*', 25));
                    Console.WriteLine($"Проигрывается файл: {name}");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Проигрыш партии завершен, нажмите любую клавишу ...");
                Console.ReadLine();
            }
        }

        Queue<Party> ReadPartyes(out string name)
        {
            Queue<Party> step = null;
            name = "";

            string folder = "Party";
            var listOfFiles = new DirectoryInfo(folder).GetFiles("*.dat");
            int Counter = 1;

            Console.WriteLine("Список сохраненных партий");
            Console.WriteLine(new string('*', 25));
            foreach (var item in listOfFiles)
            {
                Console.WriteLine(Counter + ". " + item.Name);
                Counter++;
            }
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("Выберите партию чтобы проиграть");

            var number = Console.ReadLine();
            var index = int.TryParse(number, out int res);
            if (res > 0 && res <= listOfFiles.Length)
            {
                name = listOfFiles[res - 1].Name;
                string fileName = listOfFiles[res - 1].FullName;
                step = partyPlayer.Deserialize(fileName);
            }

            return step;
        }



        void KeyPress()
        {
            var key = Console.ReadKey();
            Move(key.Key);
        }

        void Draw()
        {
            Clear();
            Console.WriteLine(new string('*', 25));
            Console.WriteLine();
            Canvas.Draw();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("Ходит игрок: " + CurrentPlayer.Name);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("Игрок " + player1.Name);
            Console.WriteLine("Ходит клавишами: Вверх, Вниз, Влево, Вправо");
            Console.WriteLine();
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("Игрок " + player2.Name);
            Console.WriteLine("Ходит клавишами: Num1, Num2, Num3");
        }

        void Move(ConsoleKey Key)
        {
            if (Canvas.CheckPosition(CurrentPlayer, Key))
            {
                CurrentPlayer.Move(Key);
                Canvas.SetPoints(player1, player2);
                AddLogStep(Key);
                CheckWin();
                SwitchPlayer();
            }
        }


        void CheckWin()
        {
            if (isPlayerWin())
            {
                Congratulations();
            }
        }

        bool isPlayerWin()
        {
            return Canvas.CheckFreeStep(player1, player2);
        }

        void SwitchPlayer()
        {
            switch (PlayerTurn)
            {
                case PlayerTurn.Player1:
                    PlayerTurn = PlayerTurn.Player2;
                    CurrentPlayer = player2;
                    break;
                case PlayerTurn.Player2:
                    PlayerTurn = PlayerTurn.Player1;
                    CurrentPlayer = player1;
                    break;
            }
        }


        void Congratulations()
        {
            Clear();

            Status = false;
            Console.WriteLine("ПОЗДРАВЛЯЕМ!!!");
            Console.WriteLine(CurrentPlayer.Name  + ", вы выйграли!!!");
            Console.WriteLine(new string('-', 25));


            bool SaveStatus = true;
            while (SaveStatus)
            {
                Console.WriteLine("Сохранить партию (Y / N)?");
                var actionKey = Console.ReadKey();

                switch (actionKey.Key)
                {
                    case ConsoleKey.Y:
                        Console.Clear();

                        Console.WriteLine("Укажите наименование файла");
                        var name = Console.ReadLine();

                        string path = Directory.GetCurrentDirectory() + $@"\Party\{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")} {name} (выграл {CurrentPlayer.Name}).dat";

                        partyPlayer.Serialize(CurrentPlayer, path);

                        SaveStatus = false;
                        Console.WriteLine("Партия сохранена!!!");
                        Console.WriteLine("Нажмите любую клавишу");
                        Console.Read();


                        break;

                    case ConsoleKey.N:
                        SaveStatus = false;
                        break;
                }

            }
            Clear();
        }

        void AddLogStep(ConsoleKey Key)
        {
            partyPlayer.Add(new Party { Player1 = (Player1)player1.Clone(), Player2 = (Player2)player2.Clone(), PlayerTurn = PlayerTurn , Key = Key});
        }

        void ClearLogStep()
        {
            partyPlayer.Clear();
        }

        void Reset()
        {
            player1 = new Player1();
            player2 = new Player2();
            CurrentPlayer = player1;
            PlayerTurn = PlayerTurn.Player1;
            partyPlayer = new PartyPlayer();
            Status = true;

            AddLogStep(ConsoleKey.Enter);
            Canvas.SetPoints(player1, player2);

        }

        void Clear()
        {
            Console.Clear();
        }


    }
}
