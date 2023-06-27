using System;
using System.Linq;

namespace T5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];
            int currentIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentIndex == snake.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentIndex == snake.Length)
                        {
                            currentIndex = 0;
                        }
                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
