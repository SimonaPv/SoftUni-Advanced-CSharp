using System;
using System.Collections.Generic;

namespace T05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = array[0];
                string country = array[1];
                string city = array[2];

                if (!map.ContainsKey(continent))
                {
                    map.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!map[continent].ContainsKey(country))
                {
                    map[continent].Add(country, new List<string>());
                }

                map[continent][country].Add(city);
            }

            foreach (var (continent, countries) in map)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, city) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", city)}");
                }
            }
        }
    }
}
