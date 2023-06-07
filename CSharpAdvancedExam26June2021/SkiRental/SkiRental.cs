namespace SkiRental
{
    using System.Collections.Generic;
    using System.Text;
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Manufacturer == manufacturer && data[i].Model == model)
                {
                    data.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            int year = 0;
            Ski ski = null;

            foreach (var item in data)
            {
                if (item.Year > year)
                {
                    year = item.Year;
                    ski = item;
                }
            }

            return ski;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = null;

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Manufacturer == manufacturer && data[i].Model == model)
                {
                    ski = data[i];
                }
            }

            return ski;
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
