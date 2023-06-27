using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                {"Sink", 40},
                {"Oven", 50},
                {"Countertop", 60},
                {"Wall", 70}
            };
            Dictionary<string, int> tiles = new Dictionary<string, int>();
            Stack<int> whiteTiles = new Stack<int>();
            Queue<int> greyTiles = new Queue<int>();

            int[] white = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] grey = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < white.Length; i++)
            {
                whiteTiles.Push(white[i]);
            }
            for (int i = 0; i < grey.Length; i++)
            {
                greyTiles.Enqueue(grey[i]);
            }

            while (true)
            {
                if (!greyTiles.Any() || !whiteTiles.Any())
                {
                    break;
                }

                int currW = whiteTiles.Peek();
                int currG = greyTiles.Peek();
                bool isFitting = false;

                if (currG == currW)
                {
                    int sum = currG + currW;

                    foreach (var loc in locations)
                    {
                        if (loc.Value == sum)
                        {
                            if (!tiles.ContainsKey(loc.Key))
                            {
                                tiles.Add(loc.Key, 1);
                            }
                            else { tiles[loc.Key]++; }

                            isFitting = true;
                            break;
                        }
                    }

                    if (!isFitting)
                    {
                        if (!tiles.ContainsKey("Floor"))
                        {
                            tiles.Add("Floor", 1);
                        }
                        else { tiles["Floor"]++; }
                    }

                    if (greyTiles.Any())
                    {
                        greyTiles.Dequeue();
                    }
                    if (whiteTiles.Any())
                    {
                        whiteTiles.Pop();
                    }
                }

                else
                {
                    if (whiteTiles.Any())
                    {
                        whiteTiles.Push(whiteTiles.Pop() / 2);
                    }
                    if (greyTiles.Any())
                    {
                        greyTiles.Enqueue(greyTiles.Dequeue());
                    }
                }
            }

            if (!whiteTiles.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (!greyTiles.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");

            }

            foreach (var item in tiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
