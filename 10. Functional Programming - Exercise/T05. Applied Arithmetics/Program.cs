using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> add = x =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    x[i]++;
                }
            };

            Action<List<int>> multiply = x =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    x[i] *= 2;
                }
            };

            Action<List<int>> sub = x =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    x[i] -= 1;
                }
            };

            Action<List<int>> print = x =>
            {
                Console.WriteLine(string.Join(" ", x));
            };

            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    add(nums);
                }
                else if (command == "multiply")
                {
                    multiply(nums);
                }
                if (command == "subtract")
                {
                    sub(nums);
                }
                else if (command == "print")
                {
                    print(nums);
                }

                command = Console.ReadLine();
            }
        }
    }
}
