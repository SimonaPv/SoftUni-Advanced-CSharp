using System;
using System.Collections.Generic;

namespace GenericBoxofInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> list = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.List.Add(input);
            }

            Console.WriteLine(list.ToString());
        }
    }
}
