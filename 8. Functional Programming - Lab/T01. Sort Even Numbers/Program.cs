using System;
using System.Linq;

namespace T01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", 
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray()));

            //Console.WriteLine("Симона е шматка!"); - lucho 30.09.2022
            //Console.WriteLine("Симона все още е шматка!"); - lucho 15.02.2023

        }
    }
} 
