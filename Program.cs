using System;
using System.Collections.Generic;

namespace dotNet5776_02_2920_0267
{
    static class Utils
    {
        public static bool InRange(int value, int min, int max) // check if a number is in a certain range
        {
            return min <= value && value <= max;
        }

        public static void ListSwap<T>(List<T> l, int a, int b)
        {
            T tmp = l[a];
            l[a] = l[b];
            l[b] = tmp;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            var g = new Game();
            g.StartGame();
            Console.WriteLine(g.player1.ToString());
            Console.WriteLine(g.player2.ToString());
            Console.WriteLine(g);
            int i = 0;
            while (g.End() != true)
            {
                g.Move();
                Console.WriteLine(g);
                i++;
            }
            Console.WriteLine("The winner is {0}, it took {1} turns.", g.Winner(), i);
            Console.ReadLine();
        }
    }
}