namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            var cars = new Dictionary<string, Car>();
            GetCars(cars);
            DriveCars(cars);
            PrintCars(cars);
        }

        static void PrintCars(Dictionary<string, Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
        static void DriveCars(Dictionary<string, Car> cars)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = args[0];
                var model = args[1];
                var distance = double.Parse(args[2]);

                if (command == "Drive" && cars.ContainsKey(model))
                {
                    cars[model].Drive(distance);
                }
            }
        }
        static void GetCars(Dictionary<string, Car> cars)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelConsumptionPerKilometer = double.Parse(carInfo[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

                cars[model] = car;
            }
        }
    }
}