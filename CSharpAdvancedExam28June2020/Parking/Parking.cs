namespace Parking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Parking
    {
        List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }

        public int Count
        {
            get { return data.Count; }
        }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (car != null)
            {
                data.Remove(car);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            Car car = null;
            int year = 0;

            foreach (var item in data)
            {
                if (item.Year > year)
                {
                    year = item.Year;
                    car = item;
                }
            }

            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
