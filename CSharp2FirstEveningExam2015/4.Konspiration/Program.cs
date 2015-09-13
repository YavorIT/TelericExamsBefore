
using System;
using System.Collections.Generic;
using System.Text;

// Doesn't work Very good!
class Konspiration
{
    static void Print(string currFunction, int numbersOfMethodsUsed, List<string> methods)
    {
        Console.Write(currFunction);
        if (numbersOfMethodsUsed > 0)
        {
            Console.Write(" -> {0} -> {1}", numbersOfMethodsUsed, string.Join(", ", methods));

            Console.WriteLine();
        }
        else if (numbersOfMethodsUsed == 0)
        {
            Console.WriteLine(" -> None");
        }
    }
    static void Main()
    {
        int linesNumber = int.Parse(Console.ReadLine());
        int functionsUsed = 0;
        string currFunction = string.Empty;
        string[] lines = new string[linesNumber];
        for (int i = 0; i < linesNumber; i++)
        {
            lines[i] = Console.ReadLine();
        }

        List<string> methods = new List<string>();
        List<string> functions = new List<string>();
        int numbersOfMethodsUsed = 0;
        StringBuilder useMethod = new StringBuilder();
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("static"))
            {
                string functionName;
                int indexOfBracket = lines[i].IndexOf('(');
                int indexOfLastSpace = lines[i].LastIndexOf(' ', indexOfBracket);
                functionName = lines[i].Substring(indexOfLastSpace + 1, indexOfBracket - indexOfLastSpace - 1);
                functions.Add(functionName);
            }
        }

        int count = 1;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("static"))
            {
                if (functionsUsed > 0)
                {
                    Print(currFunction, numbersOfMethodsUsed, methods);
                    numbersOfMethodsUsed = 0;
                    methods.Clear();
                }
                functionsUsed++;
                string functionName;
                int indexOfBracket = lines[i].IndexOf('(');
                int indexOfLastSpace = lines[i].LastIndexOf(' ', indexOfBracket);
                while(lines[i][indexOfBracket - count] == ' ')
                {
                    indexOfLastSpace = lines[i].LastIndexOf(' ', indexOfBracket - count);
                    count++;
                }
                functionName = lines[i].Substring(indexOfLastSpace + 1, indexOfBracket - indexOfLastSpace - 1);
                currFunction = functionName;
                continue;
            }
            foreach (string function in functions)
            {
                if (lines[i].Contains(function))
                {
                    methods.Add(function);
                    numbersOfMethodsUsed++;
                }
            }
            if (lines[i].Contains("."))
            {
                useMethod.Clear();
                for (int j = lines[i].IndexOf('.') + 1; j < lines[i].Length; j++)
                {
                    if(char.IsLetterOrDigit(lines[i][j]))
                    {
                        useMethod.Append(lines[i][j]);
                    }
                    else if(lines[i][j] == '(')
                    {
                        if(!functions.Contains(useMethod.ToString()))
                        {
                            methods.Add(useMethod.ToString());
                        }
                        useMethod.Clear();
                        numbersOfMethodsUsed++;
                        j = lines[i].IndexOf('.', j + 1);
                    }
                    else if(lines[i][j] != ' ')
                    {
                        break;
                    }

                    if(j < 0)
                    {
                        break;
                    }
                }
            }
        }

        Print(currFunction, numbersOfMethodsUsed, methods);
    }
}