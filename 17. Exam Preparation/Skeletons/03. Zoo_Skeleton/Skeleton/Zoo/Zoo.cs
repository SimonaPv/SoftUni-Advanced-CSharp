using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public List<Animal> Animals { get; set; } = new List<Animal>();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (this.Capacity > this.Animals.Count)
            {
                if (string.IsNullOrWhiteSpace(animal.Species) || string.IsNullOrWhiteSpace(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                {
                    return "Invalid animal diet.";
                }
                else
                {
                    Animals.Add(animal);
                    return $"Successfully added {animal.Species} to the zoo.";
                }
            }
            else { return "The zoo is full."; }
        }

        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(x => x.Species == species); 
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> list = Animals.Where(x => x.Diet == diet).ToList();
            return list;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal = Animals.FirstOrDefault(x => x.Weight == weight);
            return animal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;
            foreach (var a in Animals)
            {
                if (a.Length >= minimumLength && a.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
