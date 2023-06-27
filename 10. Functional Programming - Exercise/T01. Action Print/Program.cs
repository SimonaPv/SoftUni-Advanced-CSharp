using System;
using System.Linq;

namespace T01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> action = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            action(names);
        }
    }
}
