using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
        }

        public List<Fish> Fish { get; set; } = new List<Fish>();
        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null ||fish.FishType == " " || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (this.Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = Fish.FirstOrDefault(x => x.Weight == weight);
            if (fish == null)
            {
                return false;
            }
            else
            {
                Fish.Remove(fish);
                return true;
            }
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.FirstOrDefault(x => x.FishType == fishType);
            return fish;
        }

        public Fish GetBiggestFish()
        {
            double max = 0;
            foreach (var f in Fish)
            {
                if (f.Length > max)
                {
                    max = f.Length;
                }
            }

            Fish fish = Fish.FirstOrDefault(x => x.Length == max);
            return fish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var f in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(f.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
