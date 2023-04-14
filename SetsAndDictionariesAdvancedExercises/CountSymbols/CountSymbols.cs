public class CountSymbols
{
    public static void Main()
    {
        Dictionary<char, int> charCounter = new Dictionary<char, int>();
        string input = Console.ReadLine();

        foreach (var ch in input)
        {
            if (!charCounter.ContainsKey(ch))
            {
                charCounter[ch] = 0;
            }
            charCounter[ch]++;
        }

        charCounter = charCounter.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
        foreach (var ch in charCounter)
        {
            Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
        }
    }
}