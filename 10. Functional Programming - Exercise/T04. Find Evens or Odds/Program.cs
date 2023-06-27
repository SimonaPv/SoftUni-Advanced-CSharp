using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            bool command = Console.ReadLine() == "even";

            List<int> nums = new List<int>();
            List<int> result = new List<int>();

            for (int i = array[0]; i <= array[1]; i++)
            {
                nums.Add(i);
            }

            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;

            if (command)
            {
                result = nums.FindAll(even);
            }
            else
            {
                result = nums.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
