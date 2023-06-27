using System;
using System.Collections.Generic;
using System.Linq;

namespace T2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray(); 
            Stack<int> stack = new Stack<int>();

            foreach (var num in input)
            {
                stack.Push(num);
            }

            string commands = Console.ReadLine().ToLower();

            while (commands != "end")
            {
                string[] array = commands.Split();

                string command = array[0];

                if (command == "add" && array.Length == 3)
                {
                    int num1 = int.Parse(array[1]);
                    int num2 = int.Parse(array[2]);
                    stack.Push(num1);
                    stack.Push(num2);   
                }
                
                else if (command == "remove" && array.Length == 2)
                {
                    int num = int.Parse(array[1]);  
                    if (stack.Count >= num)
                    {
                        while (num > 0)
                        {
                            stack.Pop();
                            num--;
                        }
                    }
                }

                commands = Console.ReadLine().ToLower();
            }

            int sum = 0;

            foreach (var num in stack)
            {
                sum += num;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
