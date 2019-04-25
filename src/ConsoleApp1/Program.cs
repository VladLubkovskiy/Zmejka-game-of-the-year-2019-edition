using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Game
    {
        int _FruitX;
        int _FruitY;
        int _SnakeX;
        int _SnakeY;
        int _w;
        int _h;
        public Game(int w, int h)
        {
            _w = w;
            _h =h;
            _FruitX = random.Next(1, _w - 1); 
            _FruitY = random.Next(1, _h);
            _SnakeX = random.Next(1, _w - 7);
            _SnakeY = random.Next(1, _h);
        }
        Random random = new Random();

        public void DrawFruit()
        {
            Console.SetCursorPosition(_FruitX, _FruitY);
            Console.Write("@");
        }
        public void DrawSnake()
        {
            Console.SetCursorPosition(_SnakeX, _SnakeY);
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

        public void SnakeLeft()
        {
                if (_SnakeX == 1)
                {

                }
                else
                {
                    Console.SetCursorPosition(_SnakeX, _SnakeY);
                    Console.Write(" ");
                    _SnakeX -= 1;
                    DrawSnake();
                }
     
        }
        public void SnakeRight()
        {
            if (_SnakeX == _w - 2)
            {

            }
            else
            {
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeX += 1;
                DrawSnake();
            }
        }
        public void SnakeUp()
        {
            if (_SnakeY == 1)
            {

            }
            else
            {
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeY -= 1;
                DrawSnake();
            }
        }
        public void SnakeDown()
        {
            if (_SnakeY == _h - 1)
            {

            }
            else
            {
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeY += 1;
                DrawSnake();
            }
        }
        public bool FruitEated()
        {
            return _SnakeX == _FruitX && _SnakeY == _FruitY;
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
            while (!game.FruitEated())
            {
                Console.Clear();
                game.DrawFeild();
                game.DrawFruit();
                game.DrawSnake();
                Console.SetCursorPosition(0, h + 1);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        game.SnakeUp();
                        break;
                    case ConsoleKey.LeftArrow:
                        game.SnakeLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        game.SnakeRight();
                        break;
                    case ConsoleKey.DownArrow:                        
                        game.SnakeDown();
                        break;
                }
                System.Threading.Thread.Sleep(100);
                while (Console.KeyAvailable )
                    key = Console.ReadKey();
                game.FruitEated();
            }
        }
    }
}