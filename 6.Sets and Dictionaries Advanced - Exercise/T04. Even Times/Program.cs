using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();  

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(num))
                {
                    nums.Add(num, 0);
                }
                nums[num]++;
            }

            Console.WriteLine(nums.Single(x => x.Value % 2 == 0).Key);

            //foreach (var item in nums)
            //{
            //    if (item.Value % 2 == 0)
            //    {
            //        Console.WriteLine(item.Key);
            //    }
            //}
        }
    }
}
