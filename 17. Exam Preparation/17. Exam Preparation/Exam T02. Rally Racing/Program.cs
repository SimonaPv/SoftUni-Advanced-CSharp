using System;
using System.Data;

namespace Exam_T02._Rally_Racing
{
    internal class Program
    {
        private static char[,] matrix;
        private static int carR = 0;
        private static int carC = 0;
        private static int km = 0;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            string carNum = Console.ReadLine();
            
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                          .Replace(" ", "")
                          .ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
                if (matrix[carR, carC] == 'F')
                {
                    break;
                }
                command = Console.ReadLine();
            }

            matrix[carR, carC] = 'C';

            if (command == "End")
            {
                Console.WriteLine($"Racing car {carNum} DNF.");
            }
            else
            {
                Console.WriteLine($"Racing car {carNum} finished the stage!");
            }

            Console.WriteLine($"Distance covered {km} km.");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void Move(int r, int c)
        {
            carR += r;
            carC += c;

            if (IsValid())
            {
                if (matrix[carR, carC] == '.')
                {
                    km += 10;
                }
                else if (matrix[carR, carC] == 'T')
                {
                    km += 30;
                    matrix[carR, carC] = '.';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'T')
                            {
                                carR = row;
                                carC = col;
                            }
                        }
                    }

                    matrix[carR, carC] = '.';
                }
                else if (matrix[carR, carC] == 'F')
                {
                    km += 10;
                }
            }
        }

        public static bool IsValid()
        {
            if (carR >= 0 && carR < matrix.GetLength(0) && carC >= 0 && carC < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
