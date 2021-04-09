using System;

namespace ConsoleApp1
{
    class Program
    {
        public class Player 
        {
            public string action;
            public string name;
            public delegate void ThrowHandler(string message);
            public event ThrowHandler Throw;
            public void Game(Player one, Player two)
            {
                Random r = new Random();
                if (r.Next(0, 25) != 0)
                {
                    Throw?.Invoke($"{two.name}: {two.action}");
                    this.Game(two, one);
                }
                else 
                {
                    Throw?.Invoke($"Game over, player {two.name} lose");
                }
            }
        }
        

        static void Main(string[] args)
        {
            Player a = new Player();
            a.action = "pong";
            a.name = "a";
            a.Throw += Show_Message;
            Player b = new Player();
            b.action = "ping";
            b.name = "b";
            b.Throw += Show_Message;
            Console.WriteLine($"Player {a.name} starts.");
            a.Game(a, b);

            Console.ReadKey();
        }
        private static void Show_Message(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
