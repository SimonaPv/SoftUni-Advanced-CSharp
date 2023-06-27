using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public List<Ski> Data { get; set; } = new List<Ski>();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return Data.Count; } }

        public void Add(Ski ski)
        {
            if (Data.Count < this.Capacity) { Data.Add(ski); }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null) { return false; }
            else
            {
                Data.Remove(ski);
                return true;
            }
        }

        public Ski GetNewestSki()
        {
            if (!Data.Any())
            {
                return null;
            }
            Ski ski = Data.OrderByDescending(x => x.Year).First();
            return ski;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null) { return null; }
            return ski;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in Data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
