using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
        }

        public List<Renovator> Renovators { get; set; } = new List<Renovator>();
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get { return Renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (this.Count < this.NeededRenovators)
            {
                if (renovator.Name == null || renovator.Name == string.Empty || renovator.Type == null || renovator.Type == string.Empty)
                {
                    return "Invalid renovator's information.";
                }
                if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }
                else
                {
                    Renovators.Add(renovator);
                    return $"Successfully added {renovator.Name} to the catalog.";
                }
            }
            else
            {
                return $"Renovators are no more needed.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            foreach (var ren in Renovators)
            {
                if (ren.Name == name)
                {
                    Renovators.Remove(ren);
                    return true;
                }
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removed = Renovators.RemoveAll(x => x.Type == type);
            return removed;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = Renovators.FirstOrDefault(x => x.Name == name);
            if (!Renovators.Contains(renovator))
            {
                return null;
            }
            else
            {
                renovator.Hired = true;
                return renovator;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = Renovators.Where(x => x.Days >= days).ToList();
            return renovators;
        }

        public string Report()
        {
            List<Renovator> notHired = Renovators.Where(x => x.Hired == false).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var p in notHired)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
