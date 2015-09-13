
using System;
using System.Text;

class CalculationProblem
{
    static void Main()
    {
        string[] inputNumbers = Console.ReadLine().Split(' ');
        int[] numbers = new int[10];

        int result = CalculateNumber(inputNumbers, numbers);

        string resultLetterNumber = CalculateLetterNumber(result);

        Console.WriteLine("{0} = {1}", resultLetterNumber, result);
    }

    static int CalculateNumber(string[] letterNumbers, int[] numbers)
    {
        int j = 0;
        int power = 0;
        int numberSystem = 23;
        foreach (string letterNumber in letterNumbers)
        {
            power = 0;
            for (int i = letterNumber.Length - 1; i >= 0; i--)
            {
                numbers[j] += ((int)letterNumber[i] - 97) * (int)Math.Pow(numberSystem, power);
                power++;
            }
            j++;
        }

        int result = 0;
        foreach (int number in numbers)
        {
            result += number;
        }

        return result;
    }

    static string CalculateLetterNumber(int temp)
    {
        StringBuilder resultLetterNumber = new StringBuilder();
        while (temp != 0)
        {
            resultLetterNumber.Insert(0, (char)((temp % 23) + 97));
            temp /= 23;
        }

        return resultLetterNumber.ToString();
    }
}