using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drinks = new Dictionary<string, int>()
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 }
            };
            Dictionary<string, int> myMenu = new Dictionary<string, int>();

            Queue<int> coffee = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> milk = new Stack<int>(Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse));

            while (true)
            {
                if (!coffee.Any() || !milk.Any())
                {
                    break;
                }

                int coff = coffee.Peek();
                int mil = milk.Peek();

                if (drinks.ContainsValue(coff + mil))
                {
                    foreach (var drink in drinks)
                    {
                        if (drink.Value == coff + mil)
                        {
                            if (!myMenu.ContainsKey(drink.Key))
                            {
                                myMenu.Add(drink.Key, 1);
                            }
                            else
                            {
                                myMenu[drink.Key]++;
                            }
                        }
                    }

                    coffee.Dequeue();
                    milk.Pop();
                }
                else
                {
                    coffee.Dequeue();
                    milk.Pop();
                    milk.Push(mil -= 5);
                }
            }

            if (!coffee.Any() && !milk.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else { Console.WriteLine("Coffee left: none"); }

            if (milk.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else { Console.WriteLine("Milk left: none"); }

            foreach (var drink in myMenu.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
