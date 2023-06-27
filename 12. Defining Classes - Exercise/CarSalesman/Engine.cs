using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
           this.Displacement = displacement;
           this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            if (Displacement == 0)
            {
                return $"{this.Model}:{Environment.NewLine}" +
                $"    Power: {this.Power}{Environment.NewLine}" +
                $"    Displacement: n/a{Environment.NewLine}" +
                $"    Efficiency: {this.Efficiency}";
            }
            else
            {
                return $"{this.Model}:{Environment.NewLine}" +
                $"    Power: {this.Power}{Environment.NewLine}" +
                $"    Displacement: {this.Displacement}{Environment.NewLine}" +
                $"    Efficiency: {this.Efficiency}";
            }
        }
    }
}
