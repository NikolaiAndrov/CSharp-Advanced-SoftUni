namespace ClothesMagazine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public List<Cloth> Clothes { get; private set;}

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(x => x.Color == color);
            if (cloth != null)
            {
                Clothes.Remove(cloth);
                return true;
            }
            return false;
        }

        public Cloth GetSmallestCloth()
        {
            int smallestSize = int.MaxValue;

            foreach (var cloth in Clothes)
            {
                if (cloth.Size < smallestSize)
                {
                    smallestSize = cloth.Size;
                }
            }

            return Clothes.FirstOrDefault(x => x.Size == smallestSize);
        }

        public Cloth GetCloth(string color)
        {
            return Clothes.FirstOrDefault(x => x.Color == color); 
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }

        public string Report()
        {
            Clothes = Clothes.OrderBy(x => x.Size).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");

            foreach (var cloth in Clothes)
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
