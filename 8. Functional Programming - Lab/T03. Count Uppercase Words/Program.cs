using System;
using System.Linq;

namespace T03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpperLetter = x => char.IsUpper(x[0]);

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isUpperLetter(x))
                .ToArray();

            foreach (string item in input)
            {
                Console.WriteLine(item);   
            }
        }
    }
}
