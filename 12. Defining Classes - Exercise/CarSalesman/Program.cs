using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (array.Length == 2)
                {
                    Engine engine = new Engine(array[0], int.Parse(array[1]));
                    engines.Add(engine);
                }
                else if (array.Length == 3)
                {
                    int displacement;

                    if (int.TryParse(array[2], out displacement))
                    {
                        Engine engine = new Engine(array[0], int.Parse(array[1]), displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(array[0], int.Parse(array[1]), array[2]);
                        engines.Add(engine);
                    }
                }
                else if (array.Length == 4)
                {
                    Engine engine = new Engine(array[0], int.Parse(array[1]), int.Parse(array[2]), array[3]);
                    engines.Add(engine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (array.Length == 2)
                {
                    Engine engine = engines.FirstOrDefault(x => x.Model == array[1]);
                    Car car = new Car(array[0], engine);
                    cars.Add(car);
                }
                else if (array.Length == 3)
                {
                    Engine engine = engines.FirstOrDefault(x => x.Model == array[1]);
                    int weight;

                    if (int.TryParse(array[2], out weight))
                    {
                        Car car = new Car(array[0], engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        Car car = new Car(array[0], engine, array[2]);
                        cars.Add(car);
                    }
                }
                else if (array.Length == 4)
                {
                    Engine engine = engines.FirstOrDefault(x => x.Model == array[1]);
                    Car car = new Car(array[0], engine, int.Parse(array[2]), array[3]);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
