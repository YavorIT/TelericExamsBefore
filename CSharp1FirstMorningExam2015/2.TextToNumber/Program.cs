
using System;

class TextToNumber
{
    static void Main()
    {
        long module = long.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        text = text.ToUpper();
        long result = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if(text[i] == '@')
            {
                Console.WriteLine(result);
                return;
            }else if ((int)text[i] >= 65 && (int)text[i] <= 90)
            {
                result += ((int)text[i] - 65);
            }else if((int)text[i] >= 48 && text[i] <= 57)
            {
                result *= ((int)text[i] - 48);
            }
            else
            {
                result %= module;
            }
        }
    }
}