public class Supermarket
{
    public static void Main()
    {
        var people = new Queue<string>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            if (input == "Paid")
            {
                while (people.Count > 0)
                {
                    Console.WriteLine(people.Dequeue());
                }

                continue;
            }

            people.Enqueue(input);
        }

        Console.WriteLine($"{people.Count} people remaining.");
    }
}