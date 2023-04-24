using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public string GetCarInfo(Car car)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{car.Model}:");
            sb.AppendLine($"  {car.Engine.Model}:");
            sb.AppendLine($"    Power: {car.Engine.Power}");

            if (car.Engine.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {car.Engine.Displacement}");
            }

            if (car.Engine.Efficiency == null)
            {
                sb.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
            }

            if (car.Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {car.Weight}");
            }

            if (car.Color == null)
            {
                sb.AppendLine($"  Color: n/a");
            }
            else
            {
                sb.AppendLine($"  Color: {car.Color}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
