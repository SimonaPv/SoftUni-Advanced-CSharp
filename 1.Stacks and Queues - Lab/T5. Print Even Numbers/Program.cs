using System;
using System.Collections.Generic;
using System.Linq;

namespace T5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                int currNum = queue.Dequeue();

                if (currNum % 2 == 0)
                {
                    queue.Enqueue(currNum);
                }
            }

            Console.WriteLine(String.Join(", ", queue));
        }
    }
}
