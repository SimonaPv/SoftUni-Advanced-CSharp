using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();    

            int[] delivery = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            int sum = 0;
            int racks = 0;

            foreach (var item in delivery)
            {
                stack.Push(item);
            }

            while (stack.Count > 0)
            {
                int currentCloth = stack.Peek();
                sum += currentCloth;

                if (sum > capacity)
                {
                    racks++;
                    sum = 0;
                }
                else
                {
                    stack.Pop();
                }
            }

            if (sum > 0)
            {
                racks++;
            }

            Console.WriteLine(racks);
        }
    }
}
