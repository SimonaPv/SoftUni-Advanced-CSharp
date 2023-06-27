using System;
using System.Collections.Generic;

namespace T06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string[] songs = Console.ReadLine()
                .Split(", ");

            foreach (var item in songs)
            {
                queue.Enqueue(item);
            }

            string input = Console.ReadLine();

            while (queue.Count > 0)
            {
                if (input == "Play")
                {
                    queue.Dequeue();
                }

                else if (input.Contains("Add"))
                {
                    input = input.Remove(0, 4);

                    if (!queue.Contains(input))
                    {
                        queue.Enqueue(input);
                    }
                    else
                    {
                        Console.WriteLine($"{input} is already contained!");
                    }
                }

                else if (input == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                input = Console.ReadLine(); 
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
