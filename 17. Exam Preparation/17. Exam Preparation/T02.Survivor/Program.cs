using System;
using System.Data;
using System.Linq;
using System.Numerics;

namespace T02.Survivor
{
    internal class Program
    {
        private static int tokens = 0;
        private static int opponent = 0;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();

                matrix[row] = input;
            }

            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] array = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string comm = array[0].ToLower();
                int row = int.Parse(array[1]);
                int col = int.Parse(array[2]);

                if (comm == "find")
                {
                    CollectTokens(matrix, row, col);
                }

                else if (comm == "opponent")
                {
                    string direction = array[3];
                    if (direction == "up")
                    {
                        CollectOpp(matrix, row, col);
                        if (IsValid(matrix, row, col))
                        {
                            Move(matrix, row - 1, col);
                            if (IsValid(matrix, row - 1, col))
                            {
                                Move(matrix, row - 2, col);
                                if (IsValid(matrix, row - 2, col))
                                {
                                    Move(matrix, row - 3, col);
                                }
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        CollectOpp(matrix, row, col);
                        if (IsValid(matrix, row, col))
                        {
                            Move(matrix, row + 1, col);
                            if (IsValid(matrix, row + 1, col))
                            {
                                Move(matrix, row + 2, col);
                                if (IsValid(matrix, row + 2, col))
                                {
                                    Move(matrix, row + 3, col);
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        CollectOpp(matrix, row, col);
                        if (IsValid(matrix, row, col))
                        {
                            Move(matrix, row, col - 1);
                            if (IsValid(matrix, row, col - 1))
                            {
                                Move(matrix, row, col - 2);
                                if (IsValid(matrix, row, col - 2))
                                {
                                    Move(matrix, row, col - 3);
                                }
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        CollectOpp(matrix, row, col);
                        if (IsValid(matrix, row, col))
                        {
                            Move(matrix, row, col + 1);
                            if (IsValid(matrix, row, col + 1))
                            {
                                Move(matrix, row, col + 2);
                                if (IsValid(matrix, row, col + 2))
                                {
                                    Move(matrix, row, col + 3);
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponent}");
        }
        public static void Move(char[][] matrix, int row, int col)
        {
            CollectOpp(matrix, row, col);
        }

        public static void CollectTokens(char[][] matrix, int row, int col)
        {
            if (IsValid(matrix, row, col))
            {
                if (matrix[row][col] == 'T')
                {
                    matrix[row][col] = '-';
                    tokens++;
                }
            }
        }
        public static void CollectOpp(char[][] matrix, int row, int col)
        {
            if (IsValid(matrix, row, col))
            {
                if (matrix[row][col] == 'T')
                {
                    matrix[row][col] = '-';
                    opponent++;
                }
            }
        }

        public static bool IsValid(char[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
