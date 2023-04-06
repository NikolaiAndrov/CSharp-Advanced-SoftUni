public class Crossroads
{
    public static void Main()
    {
        int greenLight = int.Parse(Console.ReadLine());
        int freeWindow = int.Parse(Console.ReadLine());
        Queue<string> cars = new Queue<string>();
        int carsPassed = 0;

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            if (input != "green")
            {
                cars.Enqueue(input);
                continue;
            }

            int currentGreenLight = greenLight;

            while (cars.Count > 0 && currentGreenLight > 0)
            {
                string car = cars.Dequeue();

                if (currentGreenLight - car.Length >= 0)
                {
                    currentGreenLight -= car.Length;
                    carsPassed++;
                    continue;
                }

                if (currentGreenLight + freeWindow - car.Length >= 0)
                {
                    currentGreenLight = 0;
                    carsPassed++;
                    continue;
                }

                int hittedChar = currentGreenLight + freeWindow;
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{car} was hit at {car[hittedChar]}.");
                Environment.Exit(0);
            }
        }

        Console.WriteLine("Everyone is safe.");
        Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
    }
}