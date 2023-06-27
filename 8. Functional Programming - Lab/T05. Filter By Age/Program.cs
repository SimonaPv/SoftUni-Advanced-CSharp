using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(array[0], int.Parse(array[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (condition == "younger")
            {
                people = people
                    .Where(x => x.Value <= age)
                    .ToDictionary(x => x.Key, y => y.Value);    
            }
            else if (condition == "older")
            {
                people = people
                    .Where(x => x.Value >= age)
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            if (format.Length == 2)
            {
                foreach (var (name, aAge) in people)
                {
                    Console.WriteLine($"{name} - {aAge}");
                }
            }
            else if (format[0] == "name")
            {
                foreach (var (name, aAge) in people)
                {
                    Console.WriteLine($"{name}");
                }
            }
            else if (format[0] == "age")
            {
                foreach (var (name, aAge) in people)
                {
                    Console.WriteLine($"{aAge}");
                }
            }
        }
    }
}
