using System;

namespace T02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] matrix = new char[rows, cols];
            int holes = 0;
            int rods = 0;
            int vRow = 0;
            int vCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'V')
                    {
                        vRow = row;
                        vCol = col;
                    }
                }
            }

            matrix[vRow, vCol] = '*';
            holes++;

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "up")
                {
                    if (vRow - 1 >= 0 && vRow - 1 < rows && vCol >= 0 && vCol < cols)
                    {
                        vRow--;

                        if (matrix[vRow, vCol] == '-')
                        {
                            matrix[vRow, vCol] = '*';
                            holes++;
                        }
                        else if (matrix[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        }
                        else if (matrix[vRow, vCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            vRow++;
                        }
                        else if (matrix[vRow, vCol] == 'C')
                        {
                            matrix[vRow, vCol] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            break;
                        }
                    }
                }
                else if (command == "down")
                {
                    if (vRow + 1 >= 0 && vRow + 1 < rows && vCol >= 0 && vCol < cols)
                    {
                        vRow++;

                        if (matrix[vRow, vCol] == '-')
                        {
                            matrix[vRow, vCol] = '*';
                            holes++;
                        }
                        else if (matrix[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        }
                        else if (matrix[vRow, vCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            vRow--;
                        }
                        else if (matrix[vRow, vCol] == 'C')
                        {
                            matrix[vRow, vCol] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            break;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (vCol - 1 >= 0 && vCol - 1 < cols && vRow >= 0 && vRow < rows)
                    {
                        vCol--;

                        if (matrix[vRow, vCol] == '-')
                        {
                            matrix[vRow, vCol] = '*';
                            holes++;
                        }
                        else if (matrix[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        }
                        else if (matrix[vRow, vCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            vCol++;
                        }
                        else if (matrix[vRow, vCol] == 'C')
                        {
                            matrix[vRow, vCol] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            break;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (vCol + 1 >= 0 && vCol + 1 < cols && vRow >= 0 && vRow < rows)
                    {
                        vCol++;

                        if (matrix[vRow, vCol] == '-')
                        {
                            matrix[vRow, vCol] = '*';
                            holes++;
                        }
                        else if (matrix[vRow, vCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        }
                        else if (matrix[vRow, vCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rods++;
                            vCol--;
                        }
                        else if (matrix[vRow, vCol] == 'C')
                        {
                            matrix[vRow, vCol] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (command == "End")
            {
                matrix[vRow, vCol] = 'V';
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
