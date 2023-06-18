using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; private set; }
        public List<Vehicle> Vehicles { get; private set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicle = Vehicles.FirstOrDefault(x => x.VIN == vin);

            if (vehicle != null)
            {
                Vehicles.Remove(vehicle);
                return true;
            }

            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            int mileage = int.MaxValue;
            Vehicle vehicle1 = null;

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.Mileage < mileage)
                {
                    mileage = vehicle.Mileage;
                    vehicle1 = vehicle;
                }
            }

            return vehicle1;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Vehicles in the preparatory:");

            foreach (Vehicle vehicle in Vehicles)
            {
                sb.AppendLine(vehicle.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
