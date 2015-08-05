
using System;

class BitsToBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string sequence = "";
        string numberBinary;
        int number;
        for (int i = 0; i < n; i++)
        {
            number = int.Parse(Console.ReadLine());
            numberBinary = Convert.ToString(number, 2).PadLeft(32, '0');
            sequence += numberBinary.Substring(2);
        }

        int maxZeroes = 0;
        int maxOnes = 0;
        int currentZeroes = 0;
        int currentOnes = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == '0')
            {
                currentOnes = 0;
                currentZeroes++;
            }
            if (sequence[i] == '1')
            {
                currentZeroes = 0;
                currentOnes++;
            }
            if(currentZeroes >= maxZeroes)
            {
                maxZeroes = currentZeroes;
            }
            if(currentOnes >= maxOnes)
            {
                maxOnes = currentOnes;
            }
        }

        Console.WriteLine(maxZeroes);
        Console.WriteLine(maxOnes);
    }
}