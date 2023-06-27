using System;
using System.Linq;

namespace T02._Help_A_Mole
{
    internal class Program
    {
        private static char[,] matrix;
        private static int mRow = 0;
        private static int mCol = 0;
        private static int points = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] array = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = array[col];
                    if (matrix[row, col] == 'M')
                    {
                        mRow = row;
                        mCol = col;
                    }
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
                if (points >= 25)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            matrix[mRow, mCol] = 'M';

            if (command == "End")
            {
                Console.WriteLine($"Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void Move(int r, int c)
        {
            matrix[mRow, mCol] = '-';
            mRow += r;
            mCol += c;

            if (IsValid())
            {
                if (char.IsDigit(matrix[mRow, mCol]))
                {
                    int num = (int)Char.GetNumericValue(matrix[mRow, mCol]);
                    points += num;
                    matrix[mRow, mCol] = '-';
                }
                else if (matrix[mRow, mCol] == 'S')
                {
                    matrix[mRow, mCol] = '-';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'S')
                            {
                                mRow = row;
                                mCol = col;
                                break;
                            }
                        }
                    }

                    matrix[mRow, mCol] = '-';
                    points -= 3;
                }
            }
            else
            {
                mRow -= r;
                mCol -= c;  
                Console.WriteLine("Don't try to escape the playing field!");
            }
        }

        public static bool IsValid()
        {
            if (mRow >= 0 && mRow < matrix.GetLength(0) && mCol >= 0 && mCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
