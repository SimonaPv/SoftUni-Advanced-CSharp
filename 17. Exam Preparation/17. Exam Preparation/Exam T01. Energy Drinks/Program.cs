using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_T01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> energy = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int caffDrinking = 0;

            while (true)
            {
                if (!caffeine.Any() || !energy.Any())
                {
                    break;
                }

                int caff = caffeine.Peek();
                int drin = energy.Peek();
                int result = caff * drin;

                if (result + caffDrinking <= 300)
                {
                    caffDrinking += result;
                    caffeine.Pop();
                    energy.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    energy.Dequeue();
                    energy.Enqueue(drin);

                    if (caffDrinking - 30 > 0)
                    {
                        caffDrinking -= 30;
                    }
                    else
                    {
                        caffDrinking = 0;
                    }
                }
            }

            if (energy.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energy)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {caffDrinking} mg caffeine.");
        }
    }
}
