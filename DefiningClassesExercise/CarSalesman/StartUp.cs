namespace CarSalesman
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            GetEngines(engines);
            List<Car> cars = new List<Car>();
            GetCars(engines, cars);
            PrintCars(cars);
        }

        static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                string carInfo = car.GetCarInfo(car);
                Console.WriteLine(carInfo);
            }
        }
        static void GetCars(Dictionary<string, Engine> engines, List<Car> cars)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Car car = new Car();
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineType = carInfo[1];
                car.Model = model;
                car.Engine = engines[engineType];

                if (carInfo.Length >= 3)
                {
                    int weight = 0;
                    bool parsed = int.TryParse(carInfo[2], out weight);

                    if (parsed)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }

                if (carInfo.Length == 4)
                {
                    string color = carInfo[3];
                    car.Color = color;
                }

                cars.Add(car);
            }
        }
        static void GetEngines(Dictionary<string, Engine> engines)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine();

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                engine.Model = model;
                engine.Power = power;

                if (engineInfo.Length >= 3)
                {
                    int displacement = 0;
                    bool parsed = int.TryParse(engineInfo[2], out displacement);

                    if (parsed)
                    {
                        engine.Displacement = displacement;
                    }
                    else 
                    {
                        engine.Efficiency = engineInfo[2];
                    }
                }
                if (engineInfo.Length == 4)
                {
                    string efficiency = engineInfo[3];
                    engine.Efficiency = efficiency;
                }

                if (!engines.ContainsKey(model))
                {
                    engines.Add(model, engine);
                }
            }
        }
    }
}