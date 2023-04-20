public class TriFunction
{
    public static void Main()
    {
        Func<int, string[], string> properName = (size, names) =>
        {
            var nameFound = string.Empty;

            foreach (var name in names)
            {
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }

                if (sum >= size)
                {
                    nameFound = name;
                    break;
                }
            }

            return nameFound;
        };
        var size = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var name = properName(size, names);
        Console.WriteLine(name);
    }
}