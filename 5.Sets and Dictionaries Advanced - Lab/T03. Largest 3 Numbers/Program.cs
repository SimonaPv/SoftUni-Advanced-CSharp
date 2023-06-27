using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            nums = nums
                .OrderByDescending(x => x)
                .Take(3)
                .ToArray();

            Console.WriteLine(String.Join(" ", nums));

            //int count = 0;
            //foreach (var item in nums)
            //{
            //    if (count == 3)
            //    {
            //        return;
            //    }
            //    Console.Write(item + " ");
            //    count++;
            //}
        }
    }
}
