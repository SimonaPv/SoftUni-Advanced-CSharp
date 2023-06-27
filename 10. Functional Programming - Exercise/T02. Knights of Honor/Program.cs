using System;

namespace T02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> action = x =>
                {
                    foreach (var name in x)
                    {
                        Console.WriteLine($"Sir {name}");
                    }
                };

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            action(names);
        }
    }
}
