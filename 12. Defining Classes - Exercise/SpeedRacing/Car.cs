using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.DistanceTraveled = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double DistanceTraveled { get; set; }

        public void Drive(double amountOfKm)
        {
            if (this.FuelConsumptionPerKilometer * amountOfKm <= this.FuelAmount)
            {
                this.DistanceTraveled += amountOfKm;
                this.FuelAmount -= this.FuelConsumptionPerKilometer * amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
