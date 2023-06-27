using System;
using System.Linq;

namespace T04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> action = x => x + x * 0.2;

            double[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(action)
                .ToArray();

            foreach (var item in nums)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
