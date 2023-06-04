namespace Drones
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public double LandingStrip { get; private set; }
        public int Count
        {
            get { return Drones.Count; }
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(drone.Name) ||
                string.IsNullOrWhiteSpace(drone.Brand) ||
                drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }

            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(d => d.Name == name);

            if (drone == null)
            {
                return false;
            }

            Drones.Remove(drone);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;

            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Brand == brand)
                {
                    Drones.RemoveAt(i);
                    count++;
                    i--;
                }
            }
            
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flown = new List<Drone>();

            foreach (Drone drone in Drones)
            {
                if (drone.Range >= range)
                {
                    drone.Available = false;
                    flown.Add(drone);
                }
            }

            return flown;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");

            foreach (Drone drone in Drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
