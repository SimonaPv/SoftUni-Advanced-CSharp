using System;

namespace T07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string, int> predic = (name, n) =>
            {
                if (name.Length <= n)
                {
                    Console.WriteLine(name); ;
                }
                
            };

            int n = int.Parse(Console.ReadLine());

            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in array)
            {
                predic(name, n);
            }
        }
    }
}
