using System;
using System.Collections.Generic;
using System.Linq;

namespace T3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] math = Console.ReadLine()
                .Split();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < math.Length; i++)
            {
                stack.Push(math[i]);

                if (stack.Count == 3)
                {
                    int second = int.Parse(stack.Pop());
                    char sign = char.Parse(stack.Pop());
                    int first = int.Parse(stack.Pop());
                    int result = 0;

                    if (sign == '+')
                    {
                        result = first + second;
                    }
                    else if (sign == '-')
                    {
                        result = first - second;
                    }

                    stack.Push(result.ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
