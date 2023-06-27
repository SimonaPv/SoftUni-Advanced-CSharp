using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace T2._Beaver_at_Work
{
    internal class Program
    {
        private static char[,] matrix;
        private static Stack<char> branches;
        private static int bRow = 0;
        private static int bCol = 0;
        private static int branchCount = 0;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            matrix = new char[rows, cols];
            branches = new Stack<char>();

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        bRow = row;
                        bCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        branchCount++;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "up")
                {
                    
                }
                else if (command == "down")
                {

                }
                else if (command == "left")
                {
                    
                }
                else if (command == "right")
                {
                    
                }
            }
        }

        public static void Move(int row, int col)
        {
            matrix[row, col] = '-';

            if (char.IsLower(matrix[bRow, bCol]))
            {
                branches.Push(matrix[bRow, bCol]);
                branchCount--;
            }
            else if (matrix[row, col] == 'F')
            {
                
            }
            matrix[bRow, bCol] = 'B';
        }

        public static void Fish(string command)
        {
            if (command == "up")
            {

            }
        }
    }
}
