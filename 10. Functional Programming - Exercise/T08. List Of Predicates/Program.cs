using System;
using System.Collections.Generic;
using System.Linq;

namespace T08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            int endRange = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            int[] numbers = Enumerable.Range(1, endRange).ToArray();

            foreach (var divider in dividers)
            {
                predicates.Add(p => p % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var match in predicates)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{number} ");
                }




                //Func<List<int>, List<int>, int, List<int>, List<int>> func = (devider, num, n, list) =>
                //{
                //    for (int i = 1; i < n; i++)
                //    {
                //        for (int j = 0; j < devider.Count; j++)
                //        {
                //            if (num[i] % devider[j] == 0)
                //            {
                //                if (j == devider.Count - 1)
                //                {
                //                    list.Add(num[i]);
                //                }
                //            }
                //
                //            else
                //            {
                //                break;
                //            }
                //        }
                //    }
                //
                //    return list;
                //};
                //
                //int n = int.Parse(Console.ReadLine());
                //
                //List<int> deviders = Console.ReadLine()
                //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                //    .Select(int.Parse)
                //    .ToList();
                //
                //List<int> nums = new List<int>();
                //for (int i = 1; i <= n; i++)
                //{
                //    nums.Add(i);
                //}
                //
                //List<int> list = new List<int>();
                //
                //func(deviders, nums, n, list);
                //
                //Console.WriteLine(String.Join(" ", list));
            }
        }
    }
}
