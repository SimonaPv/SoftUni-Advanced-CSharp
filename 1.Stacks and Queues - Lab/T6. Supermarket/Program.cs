using System;
using System.Collections.Generic;

namespace T6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                while (input != "Paid" && input != "End")
                {
                    queue.Enqueue(input);
                    input = Console.ReadLine();
                }

                while (queue.Count > 0 && input == "Paid")
                {
                    Console.WriteLine(queue.Dequeue());
                }

                if (input != "End")
                {
                    input = Console.ReadLine();
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
