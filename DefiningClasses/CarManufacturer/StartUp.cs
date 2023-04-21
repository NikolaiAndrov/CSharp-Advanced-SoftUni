namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            GetTires(tires);

            List<Engine> engines = new List<Engine>();
            GetEngines(engines);

            List<Car> cars = new List<Car>();
            GetCars(tires, engines, cars);

            PrintSpecialCars(cars);
        }

        static void PrintSpecialCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                double pressure = 0;

                foreach (var tyre in car.Tires)
                {
                    pressure += tyre.Pressure;
                }

                if (pressure >= 9 && pressure <= 10 &&
                    car.Year >= 2017 &&
                    car.Engine.HorsePower > 330)
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
        static void GetCars(List<Tire[]> tires, List<Engine> engines, List<Car> cars)
        {
            string input;
            while ((input = Console.ReadLine()) != "Show special")
            {
                var carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var make = carInfo[0];
                var model = carInfo[1];
                var year = int.Parse(carInfo[2]);
                var fuelQuantity = double.Parse(carInfo[3]);
                var fuelConsumption = double.Parse(carInfo[4]);
                var engineIndex = int.Parse(carInfo[5]);
                var tiresIndex = int.Parse(carInfo[6]);
                var tiresPair = tires[tiresIndex];
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tiresPair);
                cars.Add(car);
            }
        }
        static void GetEngines(List<Engine> engines)
        {
            string input;
            while ((input = Console.ReadLine()) != "Engines done")
            {
                var engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var hp = int.Parse(engineInfo[0]);
                var cubicCapacity = double.Parse(engineInfo[1]);
                Engine engine = new Engine(hp, cubicCapacity);
                engines.Add(engine);
            }
        }
        static void GetTires(List<Tire[]> tires)
        {
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                var tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] tirePair = new Tire[tireInfo.Length / 2];
                var j = 0;

                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    var year = int.Parse(tireInfo[i]);
                    var pressure = double.Parse(tireInfo[i + 1]);

                    tirePair[j] = new Tire(year, pressure);
                    j++;
                }

                tires.Add(tirePair);
            }
        }
    }
}