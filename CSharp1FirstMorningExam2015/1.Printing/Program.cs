
using System;

class Printing
{
    static void Main()
    {
        double students = double.Parse(Console.ReadLine());

        double sheets = double.Parse(Console.ReadLine());

        double price = double.Parse(Console.ReadLine());

        int realmContains = 500;

        double count = (students * sheets) / realmContains;

        Console.WriteLine("{0:F2}", count * price);
    }
}