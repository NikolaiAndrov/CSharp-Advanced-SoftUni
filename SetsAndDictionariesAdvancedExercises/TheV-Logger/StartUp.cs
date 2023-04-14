public class StartUp
{
    public static void Main()
    {
        var vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
        string followers = "followers";
        string following = "following";

        string input;

        while ((input = Console.ReadLine()) != "Statistics")
        {
            string[] vloggersInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string username = vloggersInfo[0];
            string action = vloggersInfo[1];
            string followedUsername = vloggersInfo[2];

            if (action == "joined")
            {
                if (!vloggers.ContainsKey(username))
                {
                    vloggers[username] = new Dictionary<string, SortedSet<string>>();
                    vloggers[username][followers] = new SortedSet<string>();
                    vloggers[username][following] = new SortedSet<string>();
                }
            }
            else if (action == "followed")
            {
                if (vloggers.ContainsKey(username) && 
                    vloggers.ContainsKey(followedUsername) &&
                    username != followedUsername)
                {
                    vloggers[username][following].Add(followedUsername);
                    vloggers[followedUsername][followers].Add(username);
                }
            }
        }

        PrintVloggers(vloggers);
    }
    static void PrintVloggers(Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers)
    {
        Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
        int counter = 0;

        foreach (var vlogger in vloggers.OrderByDescending(x => x.Value["followers"].Count())
            .ThenBy(x => x.Value["following"].Count()))
        {
            counter++;
            if (counter == 1)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                foreach (var follower in vlogger.Value["followers"])
                {
                    Console.WriteLine($"*  {follower}");
                }

                continue;
            }

            Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
        }
    }
}