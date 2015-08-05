using System;
using System.Numerics;

class SaddyKopper
{
    static void Main()
    {
        string number = Console.ReadLine();
        BigInteger publicNumber = BigInteger.Parse(number);
        BigInteger resultNumber = 1;
        int temporaryNumber;
        int transformations = 0;
        while (true)
        {
            temporaryNumber = 0;
            publicNumber /= 10;
            number = publicNumber.ToString();
            for (int i = 0; i < number.Length; i += 2)
            {
                temporaryNumber += ((int)number[i] - 48);
            }
            if (temporaryNumber != 0)
            {
                resultNumber *= (ulong)temporaryNumber;
            }
            if (publicNumber == 0)
            {
                publicNumber = resultNumber;
                resultNumber = 1;
                transformations++;
                if (publicNumber < 10)
                {
                    Console.WriteLine("{0}", transformations);
                    Console.WriteLine("{0}", publicNumber);
                    return;
                }
                if (transformations == 10)
                {
                    Console.WriteLine("{0}", publicNumber);
                    return;
                }
            }
        }
    }
}