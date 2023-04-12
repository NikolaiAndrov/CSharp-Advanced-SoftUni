public class CitiesByContinentAndCountry
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, List<string>>> globe = new Dictionary<string, Dictionary<string, List<string>>>();
        PopolateContinents(globe);
        PrintContinentInfo(globe);
    }

    static void PrintContinentInfo(Dictionary<string, Dictionary<string, List<string>>> globe)
    {
        foreach (var continent in globe)
        {
            Console.WriteLine(continent.Key + ":");

            foreach (var country in continent.Value)
            {
                Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
            }
        }
    }
    static void PopolateContinents(Dictionary<string, Dictionary<string, List<string>>> globe)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] contientInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string continent = contientInfo[0];
            string country = contientInfo[1];
            string city = contientInfo[2];

            if (!globe.ContainsKey(continent))
            {
                globe[continent] = new Dictionary<string, List<string>>();
            }

            if (!globe[continent].ContainsKey(country))
            {
                globe[continent][country] = new List<string>();
            }

            globe[continent][country].Add(city);
        }
    }
}