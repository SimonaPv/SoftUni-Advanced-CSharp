using System;
using System.Linq;

namespace T4._Matrix_Shuffling
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
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] colData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colData[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (IsValidCommand(rowAndCol, array))
                {
                    int row1 = int.Parse(array[1]);
                    int col1 = int.Parse(array[2]);
                    int row2 = int.Parse(array[3]);
                    int col2 = int.Parse(array[4]);
                    
                    string tempValue = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tempValue;

                    PrintMatrix(matrix);
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
        static void PrintMatrix(string[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IsValidCommand(int[] dimensions, string[] tokens)
        {
            return
                tokens[0] == "swap"
                && tokens.Length == 5
                && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < dimensions[0]
                && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < dimensions[1]
                && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < dimensions[0]
                && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < dimensions[1];
        }
    }
}
