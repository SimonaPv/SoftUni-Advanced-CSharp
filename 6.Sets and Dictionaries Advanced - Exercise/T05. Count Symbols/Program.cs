using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i], 0);
                }

                dict[input[i]]++;   
            }

            dict = dict
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);    

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
