using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (int order in orders)
            {
                queue.Enqueue(order);   
            }

            Console.WriteLine(queue.Max());

            while(queue.Count > 0)
            {
                int currentOrder = queue.Peek();
                quantity -= currentOrder;

                if (quantity >= 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count <= 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
