
using System;

class Cube
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(" ");
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(":");
        }

        int spaces = n - 2;
        int slashes = n - 2;
        int xs = 0;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine();
            for (int k = 0; k < spaces; k++)
            {
                Console.Write(" ");
            }
            Console.Write(":");
            if (i != n - 2)
            {
                for (int k = 0; k < slashes; k++)
                {
                    Console.Write("/");
                }
            }
            else
            {
                for (int k = 0; k < n - 2; k++)
                {
                    Console.Write(":");
                }
            }
            Console.Write(":");
            for (int k = 0; k < xs; k++)
            {
                Console.Write("X");
            }
            Console.Write(":");
            spaces--;
            xs++;
        }

        spaces = n - 2;
        xs = n - 3;
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine();
            Console.Write(":");
            for (int k = 0; k < spaces; k++)
            {
                Console.Write(" ");
            }
            Console.Write(":");
            for (int k = 0; k < xs; k++)
            {
                Console.Write("X");
            }
            Console.Write(":");
            xs--;
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            Console.Write(":");
        }
        Console.WriteLine();
    }
}