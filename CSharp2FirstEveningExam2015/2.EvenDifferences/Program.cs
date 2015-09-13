
using System;
using System.Numerics;

class EvenDifferences
{
    static void Main()
    {
        string[] inputSequence = Console.ReadLine().Split(' ');
        BigInteger[] numbers = new BigInteger[200];
        for (int i = 0; i < inputSequence.Length; i++)
        {
            numbers[i] = int.Parse(inputSequence[i]);
        }
        int j = 1;
        BigInteger absoluteDiff = 0;
        BigInteger resultEvenAbsoluteDifferences = 0;
        while(j < inputSequence.Length)
        {
            if (numbers[j] < numbers[j - 1])
            {
                absoluteDiff = numbers[j - 1] - numbers[j];
            }else
            {
                absoluteDiff = numbers[j] - numbers[j - 1];
            }

            if(absoluteDiff % 2 == 0)
            {
                j += 2;
                resultEvenAbsoluteDifferences += absoluteDiff;
            }
            else
            {
                j += 1;
            }
        }

        Console.WriteLine(resultEvenAbsoluteDifferences);
    }
}