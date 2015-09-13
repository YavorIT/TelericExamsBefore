using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
class BadCat
{
    static void Main()
    {
        StringBuilder result = new StringBuilder();
        int N = int.Parse(Console.ReadLine());
        string[] lines = new string[N];
        for (int i = 0; i < N; i++)
        {
            lines[i] = Console.ReadLine();
        }

        var numbers = new List<int>();

        for (int i = 0; i < lines.Length; i++)
        {
            int add = int.Parse(lines[i][0].ToString());
            if (!numbers.Contains(add))
            {
                numbers.Add(add);
            }
            add = int.Parse(lines[i][lines[i].Length - 1].ToString());
            if (!numbers.Contains(add))
            {
                numbers.Add(add);
            }
        }

        numbers.Sort();

        foreach (string line in lines)
        {
            if (line.Contains("after"))
            {
                int lastNumber = int.Parse(line[line.Length - 1].ToString());
                int firstNumber = int.Parse(line[0].ToString());
                int lastIndex = numbers.IndexOf(lastNumber);
                int firstIndex = numbers.IndexOf(firstNumber);

                if (firstIndex < lastIndex)
                {
                    int temp = numbers[lastIndex];
                    numbers[lastIndex] = numbers[firstIndex];
                    numbers[firstIndex] = temp;
                }
            }
            else
            {
                int lastNumber = int.Parse(line[line.Length - 1].ToString());
                int firstNumber = int.Parse(line[0].ToString());
                int lastIndex = numbers.IndexOf(lastNumber);
                int firstIndex = numbers.IndexOf(firstNumber);

                if (firstIndex > lastIndex)
                {
                    int temp = numbers[lastIndex];
                    numbers[lastIndex] = numbers[firstIndex];
                    numbers[firstIndex] = temp;
                }
            }
        }

        foreach (int number in numbers)
        {
            Console.Write("{0}", number);
        }
        Console.WriteLine();
    }
}