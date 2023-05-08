using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public List<Fish> Fish { get; private set; }

        public int Count
        {
            get { return Fish.Count; }
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " "
                || fish.Length <= 0 || fish.Weight <= 0) 
            {
                return "Invalid fish.";
            }

            if (Capacity == Fish.Count)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            for (int i = 0; i < Fish.Count; i++)
            {
                if (Fish[i].Weight == weight)
                {
                    Fish.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            double longestFish = double.MinValue;
            int index = -1;

            for (int i = 0; i < Fish.Count; i++)
            {
                if (Fish[i].Length > longestFish)
                {
                    longestFish = Fish[i].Length;
                    index = i;
                }
            }

            return Fish[index];
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            Fish = Fish.OrderByDescending(x => x.Length).ToList();

            foreach (var item in Fish)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
