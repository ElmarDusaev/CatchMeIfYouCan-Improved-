using CatchMeIfYouCanImproved.Players;
using System;

namespace CatchMeIfYouCanImproved.Canvases
{
    static class Canvas
    {
        static int[,] canvas = new int[5, 3];
        static int rows;
        static int columns;

        static Canvas()
        {
            rows = canvas.GetUpperBound(0) + 1;
            columns = canvas.Length / rows;

            Reset();
        }

        public static void Reset()
        {
            for (int X = 0; X < rows; X++)
            {
                for (int Y = 0; Y < columns; Y++)
                {
                    canvas[X, Y] = 0;
                }
            }

            canvas[rows - 1, 0] = -1;
            canvas[rows - 1, columns - 1] = -1;
            canvas[0, columns - 1] = -1;
            canvas[0, 0] = -1;

        }

        public static void SetPoints(Player1 player1, Player2 player2)
        {
            Reset();

            canvas[player2[0].X, player2[0].Y] = 1;
            canvas[player1[0].X, player1[0].Y] = 2;
            canvas[player1[1].X, player1[1].Y] = 2;
            canvas[player1[2].X, player1[2].Y] = 2;

        }
        public static void Draw()
        {
            for (int X = 0; X < rows; X++)
            {
                for (int Y = 0; Y < columns; Y++)
                {
                    if (canvas[X, Y] == -1)
                    {
                        Console.Write("       ");
                        continue;
                    }

                    if (canvas[X, Y] == 1)
                    {
                        Console.Write("[  *  ]");
                    }
                    else if (canvas[X, Y] == 2)
                    {
                        Console.Write("[  X  ]");
                    }
                    else
                    {
                        Console.Write("[     ]");
                    }

                }
                Console.WriteLine();
            }
        }


        public static bool CheckPosition(Player player, ConsoleKey key)
        {

            var temp = (Player)player.Clone();
            temp.Move(key);
            var figure = temp.GetFigure(key);
            if (figure != null)
            {
                int X = figure.X;
                int Y = figure.Y;

                if ((X >= 0 && X <= rows - 1) && (Y >= 0 && Y <= columns - 1) && canvas[X, Y] == 0)
                    return true;
            }

            return false;
        }

        public static bool CheckFreeStep(Player player1, Player player2)
        {
            if (player2[0].X > player1[0].X && player2[0].X > player1[1].X && player2[0].X > player1[2].X) return true;

            if(!CheckPosition(player2, ConsoleKey.DownArrow) && !CheckPosition(player2, ConsoleKey.UpArrow) && !CheckPosition(player2, ConsoleKey.LeftArrow) && !CheckPosition(player2, ConsoleKey.RightArrow)) return true;

            return false;
        }
    }
}
