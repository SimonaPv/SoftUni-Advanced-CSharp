using System;
using System.Collections.Generic;
using System.Linq;

namespace T06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, Predicate<int>, List<int>> func = (numbers, match) =>
            {
                List<int> result = new List<int>();

                foreach (var number in numbers)
                {
                    if (!match(number))
                    {
                        result.Add(number);
                    }
                }
                
                result.Reverse();

                return result;
            };

            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int num = int.Parse(Console.ReadLine());

            nums = func(nums, n => n % num == 0);

            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
