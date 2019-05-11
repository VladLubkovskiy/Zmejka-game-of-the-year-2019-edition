using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{  
    class Snake
    {
        public Random random = new Random();
        int _SnakeX;
        int _SnakeY;
        public Snake(int w, int h)
        {
            _SnakeX = random.Next(1, w - 1);
            _SnakeY = random.Next(1, h);
        }
        public void Draw()
        {
            Console.SetCursorPosition(_SnakeX, _SnakeY);
            Console.Write("z");
        }
        public void SnakeLeft()
        {
            if (!(_SnakeX == 1))
            {           
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeX -= 1;
                Draw();
            }
        }
        public void SnakeRight()
        {
            if (!(_SnakeX == w - 2))
            {
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeX += 1;
                Draw();
            }
        }
        public void SnakeUp()
        {
            if (!(_SnakeY == 1))
            {
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeY -= 1;
                Draw();
            }
        }
        public void SnakeDown()
        {
            if (!(_SnakeY == h - 1))
            {
                Console.SetCursorPosition(_SnakeX, _SnakeY);
                Console.Write(" ");
                _SnakeY += 1;
                Draw();
            }
        }
        public int GetSnakeX()
        {
            return _SnakeX;
        }
        public int GetSnakeY()
        {
            return _SnakeY;
        }
    }
    class Fruit
    {
        public Random random = new Random();
        Snake _snake;
        int _FruitX;
        int _FruitY;
        public Fruit(int w, int h)
        {
            _FruitX = random.Next(1, w - 1);
            _FruitY = random.Next(1, h);
            _snake = new Snake(w, h);
        }
        public void Draw()
        {
            Console.SetCursorPosition(_FruitX, _FruitY);
            Console.Write("@");
        }
        public void NewFruit(int w, int h)
        {
            _FruitX = random.Next(1, w - 1);
            _FruitY = random.Next(1, h);
        }
        public bool IsFruitEated(int _SnakeX, int _SnakeY)
        {
            return _SnakeX == _FruitX && _SnakeY == _FruitY;
        }
        public int GetFruitX()
        {
            return _FruitX;
        }
        public int GetFruitY()
        {
            return _FruitY;
        }
    }
    class Field
    {
        public void Draw(int w, int h)
        {
            for (int i = 0; i < w; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, h);
                Console.Write("#");
            }
            for (int c = 1; c < h; c++)
            {
                Console.SetCursorPosition(0, c);
                Console.Write("#");
                Console.SetCursorPosition(w - 1, c);
                Console.Write("#");
            }
        }
    }
    class Game
    {       
        public Random random = new Random();
        Field _field;
        Snake _snake;
        Fruit _fruit;
        ConsoleKeyInfo _key;
        int _w;
        int _h;
        int _score = -1;
        public Game(int w, int h)
        {
            _w = w;
            _h =h;           
            _snake = new Snake(w, h);
            _fruit = new Fruit(w, h);
            _field = new Field();
        }
        public void DrawGame()
        {
            _field.Draw(_w, _h);
            _fruit.Draw();
            _snake.Draw();
        }
        public int GetScore()
        {
            return _score;
        }
        public void IncreaseScoreAndAddNewFruit()
        {
            if (_fruit.IsFruitEated(_snake.GetSnakeX(), _snake.GetSnakeY()))
            {
                _fruit.NewFruit(_w, _h);
                _score++;
            }
        }
        public bool IsGameEnded()
        {
            return _score == 20;
        }
        public void GetKey(ConsoleKeyInfo key)
        {
            _key = key;
        }
        public void Move()
        {
            switch (_key.Key)
            {
                case ConsoleKey.UpArrow:
                    _snake.SnakeUp();
                    break;
                case ConsoleKey.LeftArrow:
                    _snake.SnakeLeft();
                    break;
                case ConsoleKey.RightArrow:
                    _snake.SnakeRight();
                    break;
                case ConsoleKey.DownArrow:
                    _snake.SnakeDown();
                    break;
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
            while (!game.IsGameEnded())
            {
                Console.Clear();
                game.DrawGame();
                Console.SetCursorPosition(0, h + 1);
                Console.Write("Score: " + game.GetScore());
                game.Move();
                System.Threading.Thread.Sleep(100);
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                    game.GetKey(key);
                }
                game.IncreaseScoreAndAddNewFruit();
            }
        }
    }
}