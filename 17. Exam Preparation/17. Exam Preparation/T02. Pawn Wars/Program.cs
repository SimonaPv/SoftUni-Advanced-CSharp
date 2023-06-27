using System;
using System.ComponentModel;

namespace T02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];
            int wRow = 0;
            int wCol = 0;
            int bRow = 0;
            int bCol = 0;

            for (int row = 0; row < 8; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'w')
                    {
                        wRow = row;
                        wCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        bRow = row;
                        bCol = col;
                    }
                }
            }

            while (true)
            {
                if (matrix[wRow - 1, wCol - 1] == 'b' || matrix[wRow - 1, wCol + 1] == 'b')
                {
                    CoordWhite(bRow, bCol);
                    break;
                }
                else
                {
                    matrix[wRow, wCol] = '-';
                    wRow--;
                    matrix[wRow, wCol] = 'w';

                    if (wRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {LetterWhite(wCol)}8.");
                        break;
                    }
                }

                if (matrix[bRow + 1, bCol + 1] == 'w' || matrix[bRow + 1, bCol - 1] == 'w')
                {
                    CoordBlack(wRow, wCol);
                    break;
                }
                else
                {
                    matrix[bRow, bCol] = '-';
                    bRow++;
                    matrix[bRow, bCol] = 'b';

                    if (bRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {LetterWhite(bCol)}1.");
                        break;
                    }
                }
            }
        }

        public static int Number(int row)
        {
            if (row == 0)
            {
                return 8;
            }
            else if (row == 1)
            {
                return 7;
            }
            else if (row == 2)
            {
                return 6;
            }
            else if (row == 3)
            {
                return 5;
            }
            else if (row == 4)
            {
                return 4;
            }
            else if (row == 5)
            {
                return 3;
            }
            else if (row == 6)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public static char LetterWhite(int wCol)
        {
            if (wCol == 0)
            {
                return 'a';
            }
            else if (wCol == 1)
            {
                return 'b';
            }
            else if (wCol == 2)
            {
                return 'c';
            }
            else if (wCol == 3)
            {
                return 'd';
            }
            else if (wCol == 4)
            {
                return 'e';
            }
            else if (wCol == 5)
            {
                return 'f';
            }
            else if (wCol == 6)
            {
                return 'g';
            }
            else 
            {
                return 'h';
            }
        }

        public static void CoordWhite(int bRow, int bCol)
        {
            if (bCol == 0)
            {
                Console.WriteLine($"Game over! White capture on a{Number(bRow)}.");
            }
            else if (bCol == 1)
            {
                Console.WriteLine($"Game over! White capture on b{Number(bRow)}.");
            }
            else if (bCol == 2)
            {
                Console.WriteLine($"Game over! White capture on c{Number(bRow)}.");
            }
            else if (bCol == 3)
            {
                Console.WriteLine($"Game over! White capture on d{Number(bRow)}.");
            }
            else if (bCol == 4)
            {
                Console.WriteLine($"Game over! White capture on e{Number(bRow)}.");
            }
            else if (bCol == 5)
            {
                Console.WriteLine($"Game over! White capture on f{Number(bRow)}.");
            }
            else if (bCol == 6)
            {
                Console.WriteLine($"Game over! White capture on g{Number(bRow)}.");
            }
            else if (bCol == 7)
            {
                Console.WriteLine($"Game over! White capture on h{Number(bRow)}.");
            }
        }

        public static void CoordBlack(int wRow, int wCol)
        {
            if (wCol == 0)
            {
                Console.WriteLine($"Game over! Black capture on a{Number(wRow)}.");
            }
            else if (wCol == 1)
            {
                Console.WriteLine($"Game over! Black capture on b{Number(wRow)}.");
            }
            else if (wCol == 2)
            {
                Console.WriteLine($"Game over! Black capture on c{Number(wRow)}.");
            }
            else if (wCol == 3)
            {
                Console.WriteLine($"Game over! Black capture on d{Number(wRow)}.");
            }
            else if (wCol == 4)
            {
                Console.WriteLine($"Game over! Black capture on e{Number(wRow)}.");
            }
            else if (wCol == 5)
            {
                Console.WriteLine($"Game over! Black capture on f{Number(wRow)}.");
            }
            else if (wCol == 6)
            {
                Console.WriteLine($"Game over! Black capture on g{Number(wRow)}.");
            }
            else if (wCol == 7)
            {
                Console.WriteLine($"Game over! Black capture on h{Number(wRow)}.");
            }
        }
    }
}
