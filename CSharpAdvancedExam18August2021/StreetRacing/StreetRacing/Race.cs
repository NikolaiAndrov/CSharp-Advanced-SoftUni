using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new Dictionary<string, Car>();
        }

        public Dictionary<string, Car> Participants { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Laps { get; private set; }
        public int Capacity { get; private set; }
        public int MaxHorsePower { get; private set; }

        public int Count
        {
            get
            {
                return Participants.Count;
            }
        }

        public void Add(Car car)
        {
            if (Participants.Count < Capacity &&
                !Participants.ContainsKey(car.LicensePlate) &&
                car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
            {
                Participants.Remove(licensePlate);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = null;

            if (Participants.ContainsKey(licensePlate))
            {
                car = Participants[licensePlate];
            }

            return car;
        }

        public Car GetMostPowerfulCar()
        {
            Car car = null;
            int hp = 0;

            foreach (var item in Participants)
            {
                if (item.Value.HorsePower > hp)
                {
                    hp = item.Value.HorsePower;
                    car = item.Value;
                }
            }

            return car;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
