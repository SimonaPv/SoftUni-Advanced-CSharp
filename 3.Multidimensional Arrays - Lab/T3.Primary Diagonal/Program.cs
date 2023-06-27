using System;
using System.Linq;

namespace T3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowsData = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowsData[col];
                }
            }

            int matrixRow = int.Parse(Console.ReadLine());
            int matrixCol = int.Parse(Console.ReadLine());
            int biggestSum = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows - matrixRow + 1; row++)
            {
                for (int col = 0; col < cols - matrixCol + 1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];

                    if (sum > biggestSum)
                    {
                        startRow = row;
                        startCol = col;
                        biggestSum = sum;
                    }
                }
            }
            Console.WriteLine(matrix[startRow, startCol] + " " + matrix[startRow, startCol + 1]);
            Console.WriteLine(matrix[startRow + 1, startCol] + " " + matrix[startRow + 1, startCol + 1]);

            Console.WriteLine(biggestSum);
        }
    }
}
