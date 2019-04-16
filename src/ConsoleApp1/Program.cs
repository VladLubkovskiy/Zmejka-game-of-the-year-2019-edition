using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        int _w;
        int _h;
        public Game(int w, int h)
        {
            _w = w;
            _h =h;
        }
        Random random = new Random();
        public void DrawFruit()
        {
            int x = random.Next(1, _w - 1);
            int y = random.Next(1, _h);
            Console.SetCursorPosition(x, y);
            Console.Write("$");
        }
        public void DrawSnake()
        {
            int x = random.Next(1, _w - 1);
            int y = random.Next(1, _h);
            Console.SetCursorPosition(x, y);
            Console.Write("z");
        }
        public void DrawFeild()
        {
            for (int i = 0; i < _w; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, _h);
                Console.Write("#");
            }
            for (int c = 1; c < _h; c++)
            {
                Console.SetCursorPosition(0, c);
                Console.Write("#");
                Console.SetCursorPosition(_w - 1, c);
                Console.Write("#");
            }
        }
    }
    class Program 
    {
        static void Main(string[] args)
        {
            int w, h;
            w = 40;
            h = 30/2;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Game game = new Game(w,h);
            while (true) { 
                Console.Clear();
                game.DrawFeild();
                game.DrawFruit();
                game.DrawSnake();
                Console.SetCursorPosition(0, h + 1);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("Up");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("Left");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("Right");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("Down");
                        break;
                }
                key = Console.ReadKey();
            }
        }
    }
}