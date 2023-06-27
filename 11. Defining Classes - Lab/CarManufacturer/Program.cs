using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            List<Tire[]> tires = new List<Tire[]>();

            while (true)
            {
                List<Tire> currentCarTires = new List<Tire>();

                string command = Console.ReadLine();

                if (command == "No more tires")
                {
                    break;
                }
                
                double[] data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                for (int i = 0; i < data.Length; i += 2)
                {
                    Tire tire = new Tire(int.Parse(data[i].ToString()), data[i + 1]);
                    currentCarTires.Add(tire);
                }
                tires.Add(currentCarTires.ToArray());
            }

            tires.ToArray();

            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                double[] data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                for (int i = 0; i < data.Length; i += 2)
                {
                    Engine engine = new Engine(int.Parse(data[i].ToString()), data[i + 1]);
                    engines.Add(engine);
                }
            }

            engines.ToArray();

            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }

                string[] carData = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                Engine engine = engines[int.Parse(carData[5])];
                Tire[] tiresData = tires[int.Parse(carData[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tiresData);
                cars.Add(car);
            }

            Func<Tire[], double> pressureSum = p =>
            {
                double sum = 0;

                foreach (var tire in p)
                {
                    sum += tire.Pressure;
                }
                return sum;
            };

            List<Car> specialCar = cars.Where(c =>
                c.Year >= 2017 &&
                c.Engine.HorsePower > 330
                && pressureSum(c.Tires) > 9 && pressureSum(c.Tires) < 10).ToList();

            foreach (var car in specialCar)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
