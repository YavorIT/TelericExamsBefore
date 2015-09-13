using System;
using System.Collections.Generic;
using System.Text;
//Doesn't work fully
class LoverOf3
{
    static void Main()
    {
        List<string> coordinatesUsed = new List<string>();
        string[] dimms = Console.ReadLine().Split(' ');
        int rows = int.Parse(dimms[0]);
        int cols = int.Parse(dimms[1]);
        int[,] matrix = new int[rows, cols];

        FillTheMatrix(matrix);
        int result = 0;
        int newRow = matrix.GetLength(0) - 1;
        int newCol = 0;
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] inputDirr = Console.ReadLine().Split(' ');

            string dirr = inputDirr[0];
            int moveTimes = int.Parse(inputDirr[1]) - 1;

            int currCol = newCol;
            int currRow = newRow;

            switch (dirr)
            {
                case "UR":
                case "RU":
                    for (int j = 0; j < moveTimes; j++)
                    {
                        newRow -= 1;
                        newCol += 1;
                        if (newRow < 0)
                        {
                            newRow = 0;
                            newCol = currCol + j;
                            break;
                        }
                        if (newCol >= matrix.GetLength(1))
                        {
                            newCol = matrix.GetLength(1) - 1;
                            newRow = currRow - j;
                            break;
                        }
                    }
                    break;
                case "UL":
                case "LU":
                    for (int j = 0; j < moveTimes; j++)
                    {
                        newRow -= 1;
                        newCol -= 1;
                        if (newRow < 0)
                        {
                            newRow = 0;
                            newCol = currCol - j;
                            break;
                        }
                        if (newCol < 0)
                        {
                            newCol = 0;
                            newRow = currRow - j;
                            break;
                        }
                    }
                    break;
                case "DR":
                case "RD":
                    for (int j = 0; j < moveTimes; j++)
                    {
                        newRow += 1;
                        newCol += 1;
                        if (newRow >= matrix.GetLength(0))
                        {
                            newRow = matrix.GetLength(0) - 1;
                            newCol = currCol + j;
                            break;
                        }
                        if (newCol >= matrix.GetLength(1))
                        {
                            newCol = matrix.GetLength(1) - 1;
                            newRow = currRow + j;
                            break;
                        }
                    }
                    break;
                case "DL":
                case "LD":
                    for (int j = 0; j < moveTimes; j++)
                    {
                        newRow += 1;
                        newCol -= 1;
                        if (newRow >= matrix.GetLength(0))
                        {
                            newRow = matrix.GetLength(0) - 1;
                            newCol = currCol - j;
                            break;
                        }
                        if (newCol < 0)
                        {
                            newCol = 0;
                            newRow = currRow + j;
                            break;
                        }
                    }
                    break;
            }
            result += AddTheNumber(matrix, moveTimes, dirr, newRow, newCol, currRow, currCol, coordinatesUsed, result);
        }
        Console.WriteLine(result);
    }

    static int AddTheNumber(int[,] matrix, int move, string direction, int newRows, int newCols, int currRows, int currCols, List<string> coordinatesUsed, int currResult)
    {
        int result = 0;
        int row = currRows;
        int col = currCols;
        for (int i = 0; i <= move; i++)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                break;
            }
            StringBuilder coordinates = new StringBuilder();
            coordinates.Append(row);
            coordinates.Append(col);
            if (!coordinatesUsed.Contains(coordinates.ToString()))
            {
                coordinatesUsed.Add(coordinates.ToString());
                result += matrix[row, col];
            }

            col = ChangeCols(col, direction);
            row = ChangeRows(row, direction);

            coordinates.Clear();
        }

        return result;
    }

    static int ChangeCols(int currCol, string direction)
    {
        switch (direction)
        {
            case "UR":
            case "RU":
            case "DR":
            case "RD":
                currCol += 1;
                break;
            case "UL":
            case "LU":
            case "DL":
            case "LD":
                currCol -= 1;
                break;
        }
        return currCol;
    }

    static int ChangeRows(int currRow, string direction)
    {
        switch (direction)
        {
            case "UR":
            case "RU":
            case "UL":
            case "LU":
                currRow -= 1;
                break;
            case "DR":
            case "RD":
            case "DL":
            case "LD":
                currRow += 1;
                break;
        }
        return currRow;
    }

    private static void FillTheMatrix(int[,] matrix)
    {
        int numberToFillCol = 0;
        int numberToFillRow = 0;
        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            numberToFillCol = numberToFillRow;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = numberToFillCol;
                numberToFillCol += 3;
            }
            numberToFillRow += 3;
        }
    }
}