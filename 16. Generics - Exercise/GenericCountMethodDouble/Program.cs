using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<double> list = new Box<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                list.List.Add(input);
            }

            double item = double.Parse(Console.ReadLine());

            Console.WriteLine(list.Count(item));
        }
    }
}
