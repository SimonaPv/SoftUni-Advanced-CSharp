using System;
using System.Collections.Generic;

namespace GenericBoxofString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> list = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                list.List.Add(input);
            }

            Console.WriteLine(list.ToString());
        }
    }
}
