using System;
using System.Linq;

namespace GenericCountMethodString
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

            string item = Console.ReadLine();

            Console.WriteLine(list.Count(item));
        }
    }
}
