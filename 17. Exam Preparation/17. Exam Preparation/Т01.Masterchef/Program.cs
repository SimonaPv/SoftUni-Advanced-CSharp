using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Т01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> menu = new Dictionary<string, int>
            {
                {"Dipping sauce", 150 },
                {"Green salad", 250 },
                {"Chocolate cake", 300 },
                {"Lobster", 400 }
            };
            Queue<int> ingredient = new Queue<int>();
            Stack<int> freshness = new Stack<int>();
            Dictionary<string, int> myMenu = new Dictionary<string, int>();

            int[] ingr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] fresh = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            for (int i = 0; i < ingr.Length; i++)
            {
                ingredient.Enqueue(ingr[i]);
            }
            for (int i = 0; i < fresh.Length; i++)
            {
                freshness.Push(fresh[i]);
            }

            while (true)
            {
                if (!ingredient.Any() || !freshness.Any())
                {
                    break;
                }

                int firstIngr = ingredient.Peek();
                int lastFresh = freshness.Peek();
                int sum = firstIngr * lastFresh;

                if (firstIngr == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }

                if (menu.ContainsValue(sum))
                {
                    foreach (var item in menu)
                    {
                        if (item.Value == sum)
                        {
                            if (!myMenu.ContainsKey(item.Key))
                            {
                                myMenu.Add(item.Key, 1);
                            }
                            else
                            {
                                myMenu[item.Key]++;
                            }
                            ingredient.Dequeue();
                            freshness.Pop();
                        }
                    }
                }

                else
                {
                    freshness.Pop();
                    firstIngr += 5;
                    ingredient.Dequeue();
                    ingredient.Enqueue(firstIngr);
                }
            }

            if (myMenu.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredient.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }

            foreach (var item in myMenu.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
