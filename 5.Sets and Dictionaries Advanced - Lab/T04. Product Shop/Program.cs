using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, double>> shop = new Dictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string[] array = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string market = array[0];
                string product = array[1];
                double price = double.Parse(array[2]);

                if (!shop.ContainsKey(market))
                {
                    shop.Add(market, new Dictionary<string, double>());
                }
                shop[market].Add(product, price);

                input = Console.ReadLine();
            }

            shop = shop
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var (market, products) in shop)
            {
                Console.WriteLine($"{market}->");

                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
