using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace RawData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            GetCars(cars);
            PrintCars(cars);
        }

        static void PrintCars(List<Car> cars)
        {
            string cargoType = Console.ReadLine();
            
            if (cargoType == "fragile")
            {
                List<Car> fragileCargo = cars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(x => x.Pressure < 1)).ToList();

                foreach (Car car in fragileCargo)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (cargoType == "flammable")
            {
                List<Car> flammableCargo = cars.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250).ToList();

                foreach(Car car in flammableCargo)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
        static void GetCars(List<Car> cars)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                List<Tire> tires = new List<Tire>();
                for (int j = 5; j <= 12; j+=2)
                {
                    double tirePressure = double.Parse(carInfo[j]);
                    int tireAge = int.Parse(carInfo[j + 1]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
        }
    }
}
