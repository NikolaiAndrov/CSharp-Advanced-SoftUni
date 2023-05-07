using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Animal> Animals { get; private set; }
        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Capacity == Animals.Count)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Species == species)
                {
                    Animals.RemoveAt(i);
                    count++;
                    i--;
                }
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> result = new List<Animal>();

            foreach (Animal animal in Animals)
            {
                if (animal.Diet == diet)
                {
                    result.Add(animal);
                }
            }
            return result;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (Animal animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
