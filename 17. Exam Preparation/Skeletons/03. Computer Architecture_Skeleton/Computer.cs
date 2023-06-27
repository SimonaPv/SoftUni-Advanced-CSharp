using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
        }
        public List<CPU> Multiprocessor { get; set; } = new List<CPU>();
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (this.Capacity > this.Multiprocessor.Count)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (cpu == null)
            {
                return false;
            }
            else
            {
                Multiprocessor.Remove(cpu);
                return true;
            }
        }

        public CPU MostPowerful()
        {
            double max = 0;
            foreach (var i in Multiprocessor)
            {
                if (i.Frequency > max)
                {
                    max = i.Frequency;
                }
            }

            CPU cpu = Multiprocessor.FirstOrDefault(x => x.Frequency == max);
            return cpu;
        }

        public CPU GetCPU(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (cpu == null)
            {
                return null;
            }
            else
            {
                return cpu;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (var i in Multiprocessor)
            {
                sb.AppendLine(i.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
