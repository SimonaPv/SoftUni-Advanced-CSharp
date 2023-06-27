using System;
using System.Linq;

namespace T1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primarySum += matrix[i, i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                secondarySum += matrix[i, matrix.GetLength(0) - i - 1];
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
