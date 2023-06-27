using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> numCount = new Dictionary<double, int>();

            foreach (double num in nums)
            {
                if (!numCount.ContainsKey(num))
                {
                    numCount.Add(num, 0);
                }

                numCount[num]++;
            }

            foreach (var num in numCount)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
