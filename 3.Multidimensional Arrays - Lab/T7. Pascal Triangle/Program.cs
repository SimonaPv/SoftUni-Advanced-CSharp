using System;

namespace T7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[rows][];
            jaggedArray[0] = new long[1] { 1 };

            for (int row = 1; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;

                for (int col = 1; col < row; col++)
                {
                    jaggedArray[row][col] = jaggedArray[row - 1][col - 1] + jaggedArray[row - 1][col];
                }
                jaggedArray[row][row] = 1;
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
