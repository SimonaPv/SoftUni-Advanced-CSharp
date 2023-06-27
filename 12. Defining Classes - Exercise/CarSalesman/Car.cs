using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            if (this.Weight == 0)
            {
                return $"{this.Model}:{Environment.NewLine}" +
                $"   {this.Engine.ToString()}{Environment.NewLine}" +
                $"  Weight: n/a{Environment.NewLine}" +
                $"  Color: {this.Color}";
            }
            else
            {
                return $"{this.Model}:{Environment.NewLine}" +
                $"    {this.Engine.ToString()}{Environment.NewLine}" +
                $"  Weight: {this.Weight}{Environment.NewLine}" +
                $"  Color: {this.Color}";
            }
        }
    }
}
