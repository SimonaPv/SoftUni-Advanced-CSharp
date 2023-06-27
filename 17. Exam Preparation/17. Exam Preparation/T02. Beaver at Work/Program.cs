using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace T02._Beaver_at_Work
{
    internal class Program
    {
        private static int bRow;
        private static int bCol;
        private static char[,] matrix;
        private static Stack<char> branches = new Stack<char>();
        private static int branchesCount = 0;
        private static string lastCommand;

        static void Main(string[] args)
        {
            //ne raboti v judge!!
            //31/100
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        bRow = row;
                        bCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        branchesCount++;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                lastCommand = command;
                if (command == "up")
                {
                    if (IsIn(bRow - 1, bCol))
                    {
                        if (char.IsLower(matrix[bRow - 1, bCol]))
                        {
                            branches.Push(matrix[bRow - 1, bCol]);
                            matrix[bRow, bCol] = '-';
                            bRow--;
                            matrix[bRow, bCol] = 'B';
                            branchesCount--;
                        }
                        else if (matrix[bRow - 1, bCol] == 'F')
                        {
                            if (bRow - 1 == 0)
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow - 1, bCol] = '-';
                                bRow = rows - 1;
                            }
                            else
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow - 1, bCol] = '-';
                                bRow = 0;
                            }
                            if (char.IsLower(matrix[bRow, bCol]))
                            {
                                branches.Push(matrix[bRow, bCol]);
                                branchesCount--;
                            }
                            matrix[bRow, bCol] = 'B';
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }
                else if (command == "down")
                {
                    if (IsIn(bRow + 1, bCol))
                    {
                        if (char.IsLower(matrix[bRow + 1, bCol]))
                        {
                            branches.Push(matrix[bRow + 1, bCol]);
                            matrix[bRow, bCol] = '-';
                            bRow++;
                            matrix[bRow, bCol] = 'B';
                            branchesCount--;
                        }
                        else if (matrix[bRow + 1, bCol] == 'F')
                        {
                            if (bRow + 1 == rows - 1)
                            {
                                matrix[bRow + 1, bCol] = '-';
                                matrix[bRow, bCol] = '-';
                                bRow = 0;
                            }
                            else
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow + 1, bCol] = '-';
                                bRow = rows - 1;
                            }

                            if (char.IsLower(matrix[bRow, bCol]))
                            {
                                branches.Push(matrix[bRow, bCol]);
                                branchesCount--;
                            }
                            matrix[bRow, bCol] = 'B';
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }
                else if (command == "left")
                {
                    if (IsIn(bRow, bCol - 1))
                    {
                        if (char.IsLower(matrix[bRow, bCol - 1]))
                        {
                            branches.Push(matrix[bRow, bCol - 1]);
                            matrix[bRow, bCol] = '-';
                            bCol--;
                            matrix[bRow, bCol] = 'B';
                            branchesCount--;
                        }
                        else if (matrix[bRow, bCol - 1] == 'F')
                        {
                            if (bCol - 1 == 0)
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow, bCol - 1] = '-';
                                bCol = cols - 1;
                            }
                            else
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow, bCol - 1] = '-';
                                bCol = 0;
                            }

                            if (char.IsLower(matrix[bRow, bCol]))
                            {
                                branches.Push(matrix[bRow, bCol]);
                                branchesCount--;
                            }
                            matrix[bRow, bCol] = 'B';
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }
                else if (command == "right")
                {
                    if (IsIn(bRow, bCol + 1))
                    {
                        if (char.IsLower(matrix[bRow, bCol + 1]))
                        {
                            branches.Push(matrix[bRow, bCol + 1]);
                            matrix[bRow, bCol] = '-';
                            bCol++;
                            matrix[bRow, bCol] = 'B';
                            branchesCount--;
                        }
                        else if (matrix[bRow, bCol + 1] == 'F')
                        {
                            if (bCol + 1 == cols - 1)
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow, bCol + 1] = '-';
                                bCol = 0;
                            }
                            else
                            {
                                matrix[bRow, bCol] = '-';
                                matrix[bRow, bCol + 1] = '-';
                                bCol = cols - 1;
                            }

                            if (char.IsLower(matrix[bRow, bCol]))
                            {
                                branches.Push(matrix[bRow, bCol]);
                                branchesCount--;
                            }
                            matrix[bRow, bCol] = 'B';
                        }
                    }
                    else
                    {
                        if (branches.Count > 0)
                        {
                            branches.Pop();
                        }
                    }
                }

                if (branchesCount <= 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (command == "end")
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public static void Move(int row, int col)
        {
            if (!IsIn(bRow + row, bCol + col))
            {
                if (branches.Count > 0)
                {
                    branches.Pop();
                }
                return;
            }
            else
            {
                matrix[bRow, bCol] = '-';
                bRow += row;
                bCol += col;

                if (char.IsLower(matrix[bRow, bCol]))
                {
                    branches.Push(matrix[bRow, bCol]);
                    matrix[bRow, bCol] = 'B';
                    branchesCount--;
                }
                else if (matrix[bRow, bCol] == 'F')
                {
                    matrix[bRow, bCol] = '-';
                    if (lastCommand == "up")
                    {
                        if (bRow == 0)
                        {
                            if (char.IsLower(matrix[matrix.GetLength(0) - 1, bCol]))
                            {
                                branches.Push(matrix[matrix.GetLength(0) - 1, bCol]);
                                branchesCount--;
                            }
                            bRow = matrix.GetLength(0) - 1;
                            matrix[bRow, bCol] = 'B';
                        }
                    }
                }
            }

        }

        public static bool IsIn(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
