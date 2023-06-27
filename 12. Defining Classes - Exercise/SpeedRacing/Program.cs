using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] array = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(array[0], double.Parse(array[1]), double.Parse(array[2]));
                cars.Add(car);
            }

            string input = Console.ReadLine();
            
            while (input != "End")
            {
                string[] array = input
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (array[0] == "Drive")
                {
                    cars.FirstOrDefault(x => x.Model == array[1]).Drive(double.Parse(array[2]));
                }

                input = Console.ReadLine();
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Model} {item.FuelAmount:f2} {item.DistanceTraveled}");
            }
        }
    }
}
