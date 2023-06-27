using System;
using System.Linq;

namespace T3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowAndCol[0];
            int cols = rowAndCol[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] colData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colData[col];
                }
            }

            int maxSum = int.MinValue;
            int squareR = 0;
            int squareC = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = 
                        matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + 
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        squareR = row;
                        squareC = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = squareR; row < squareR + 3; row++)
            {
                for (int col = squareC; col < squareC + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }                 
        }
    }
}
//Console.Write(matrix[squareR - 2, squareC - 2] + " ");
//Console.Write(matrix[squareR - 2, squareC - 1] + " ");
//Console.WriteLine(matrix[squareR - 2, squareC]);
//Console.Write(matrix[squareR - 1, squareC - 2] + " ");
//Console.Write(matrix[squareR - 1, squareC - 1] + " ");
//Console.WriteLine(matrix[squareR - 1, squareC]);
//Console.Write(matrix[squareR, squareC - 2] + " ");
//Console.Write(matrix[squareR, squareC - 1] + " ");
//Console.WriteLine(matrix[squareR, squareC]);
