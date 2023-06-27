
using System;
using System.Linq;

namespace T2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int rows = rowAndCol[0];
            int cols = rowAndCol[1];

            char[,] matrix = new char[rows, cols];
            int squares = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] colData = Console.ReadLine()
                    .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colData[col];
                }
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (matrix[row, col] == matrix[row, col - 1] && matrix[row, col] == matrix[row - 1, col] && matrix[row, col] == matrix[row - 1, col - 1])
                    {
                        squares++;
                    }
                }
            }
            Console.WriteLine(squares);
        }
    }
}
