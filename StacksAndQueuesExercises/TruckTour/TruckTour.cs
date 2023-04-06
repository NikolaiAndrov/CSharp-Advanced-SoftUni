public class TruckTour
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Queue<int> circuit = new Queue<int>();
        GetPompInfo(n, circuit);
        int startingPoint = GetStartingPoint(n, circuit);
        Console.WriteLine(startingPoint);
    }

    static int GetStartingPoint(int n, Queue<int> circuit)
    {
        int fuel = 0;
        int distance = 0;
        int startingPoint = -1;
        int iterations = 0;

        while (true)
        {
            iterations++;
            startingPoint++;

            if (startingPoint == n - 1)
            {
                startingPoint = 0;
            }

            if (iterations == n)
            {
                break;
            }

            int currentFuel = circuit.Dequeue();
            int currentDistance = circuit.Dequeue();

            circuit.Enqueue(currentFuel);
            circuit.Enqueue(currentDistance);

            fuel += currentFuel;
            distance += currentDistance;

            if (fuel - distance >= 0)
            {
                fuel -= distance;
                distance = 0;
            }
            else
            {
                fuel = 0;
                distance = 0;
                iterations = 0;
            }
        }

        return startingPoint;
    }
    static void GetPompInfo(int n, Queue<int> circuit)
    {

        for (int i = 0; i < n; i++)
        {
            int[] pompInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int fuel = pompInfo[0];
            int distance = pompInfo[1];

            circuit.Enqueue(fuel);
            circuit.Enqueue(distance);
        }
    }
}