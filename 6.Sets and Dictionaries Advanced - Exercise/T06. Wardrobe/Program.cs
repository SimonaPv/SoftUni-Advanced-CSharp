using System;
using System.Collections.Generic;

namespace T06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries); 
                string colour = input[0];
                string[] cloths = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                for (int j = 0; j < cloths.Length; j++)
                {
                    if (!wardrobe[colour].ContainsKey(cloths[j]))
                    {
                        wardrobe[colour].Add(cloths[j], 0);
                    }

                    wardrobe[colour][cloths[j]]++;
                }
            }

            string[] searching = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var (colour, cloths) in wardrobe)
            {
                Console.WriteLine($"{colour} clothes:");

                foreach (var (cloth, count) in cloths)
                {
                    if (cloth == searching[1] && colour == searching[0])
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }
        }
    }
}
