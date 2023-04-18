public class CountUppercaseWords
{
    public static void Main()
    {
        Func<string, bool> StartsWithUpperLetter = x => x[0] == char.ToUpper(x[0]) && char.IsLetter(x[0]);

        string[] words = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Where(x => StartsWithUpperLetter(x))
            .ToArray();

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
    }
}