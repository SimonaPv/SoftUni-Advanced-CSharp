using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foods = new Dictionary<string, int>();

            double[] waterNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double[] flourNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Queue<double> water = new Queue<double>();
            Stack<double> flour = new Stack<double>();

            for (int i = 0; i < waterNums.Length; i++)
            {
                water.Enqueue(waterNums[i]);
            }
            for (int i = 0; i < flourNums.Length; i++)
            {
                flour.Push(flourNums[i]);
            }

            while (true)
            {
                if (!water.Any() || !flour.Any()) { break; }

                double watNum = water.Peek();
                double floNum = flour.Peek();

                if (Baguette(watNum, floNum))
                {
                    if (!foods.ContainsKey("Baguette"))
                    {
                        foods.Add("Baguette", 1);
                    }
                    else
                    {
                        foods["Baguette"]++;
                    }
                    water.Dequeue();
                    flour.Pop();
                }

                else if (Muffin(watNum, floNum))
                {
                    if (!foods.ContainsKey("Muffin"))
                    {
                        foods.Add("Muffin", 1);
                    }
                    else
                    {
                        foods["Muffin"]++;
                    }
                    water.Dequeue();
                    flour.Pop();
                }

                else if (Bagel(watNum, floNum))
                {
                    if (!foods.ContainsKey("Bagel"))
                    {
                        foods.Add("Bagel", 1);
                    }
                    else
                    {
                        foods["Bagel"]++;
                    }
                    water.Dequeue();
                    flour.Pop();
                }
                else if (Croissant(watNum, floNum))
                {
                    if (!foods.ContainsKey("Croissant"))
                    {
                        foods.Add("Croissant", 1);
                    }
                    else
                    {
                        foods["Croissant"]++;
                    }
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    if (!foods.ContainsKey("Croissant"))
                    {
                        foods.Add("Croissant", 1);
                    }
                    else
                    {
                        foods["Croissant"]++;
                    }
                    flour.Pop();
                    water.Dequeue();
                    double flourr = floNum - watNum;
                    flour.Push(flourr);
                }
            }

            foreach (var item in foods.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (!water.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (!flour.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }


        public static bool Croissant(double water, double flour)
        {
            double[] precent = CalculateP(water, flour);
            if (precent[0] == 50 && precent[1] == 50)
            {
                return true;
            }
            return false;
        }

        public static bool Baguette(double water, double flour)
        {
            double[] precent = CalculateP(water, flour);
            if (precent[0] == 30 && precent[1] == 70)
            {
                return true;
            }
            return false;
        }

        public static bool Bagel(double water, double flour)
        {
            double[] precent = CalculateP(water, flour);
            if (precent[0] == 20 && precent[1] == 80)
            {
                return true;
            }
            return false;
        }

        public static bool Muffin(double water, double flour)
        {
            double[] precent = CalculateP(water, flour);
            if (precent[0] == 40 && precent[1] == 60)
            {
                return true;
            }
            return false;
        }

        public static double[] CalculateP(double water, double flour)
        {
            double[] arr = new double[2];
            double mix = water + flour;
            arr[0] = (water * 100) / mix;
            arr[1] = (flour * 100) / mix;
            return arr;
        }
    }
}
