public class TrafficJam
{
    public static void Main()
    {
        var cars = new Queue<string>();

        var n = int.Parse(Console.ReadLine());
        var carsPassed = 0;

        string input;

        while ((input = Console.ReadLine()) != "end")
        {
            if (input == "green")
            {
                for (int i = 0; i < n; i++)
                {
                    if (cars.Count > 0)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carsPassed++;
                    }
                    else
                    {
                        break;
                    }
                }

                continue;
            }

            cars.Enqueue(input);
        }

        Console.WriteLine($"{carsPassed} cars passed the crossroads.");
    }
}