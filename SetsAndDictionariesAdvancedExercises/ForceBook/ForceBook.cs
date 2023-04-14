public class ForceBook
{
    public static void Main()
    {
        var forceBook = new Dictionary<string, SortedSet<string>>();

        string input;
        var sides = new HashSet<string>();

        while ((input = Console.ReadLine()) != "Lumpawaroo")
        {
            var sign = string.Empty;

            if (input.Contains("|"))
            {
                sign = "|";
            }
            else if (input.Contains("->"))
            {
                sign = "->";
            }

            var args = input.Split(new char[] {'|', '-', '>'}, StringSplitOptions.RemoveEmptyEntries);

            if (sign == "|")
            {
                var currentSide = args[0].Trim();
                var name = args[1].Trim();
                sides.Add(currentSide);
                bool exists = false;

                foreach (var sideToCheck in sides)
                {
                    if (sideToCheck != currentSide && 
                        forceBook.ContainsKey(sideToCheck) && 
                        forceBook[sideToCheck].Contains(name))
                    {
                        exists = true; 
                        break;
                    }
                }

                if (exists)
                {
                    continue;
                }

                if (!forceBook.ContainsKey(currentSide))
                {
                    forceBook[currentSide] = new SortedSet<string>();
                }

                forceBook[currentSide].Add(name);
            }
            else if (sign == "->")
            {
                var name = args[0].Trim();
                var currentSide = args[1].Trim();
                sides.Add(currentSide);

                if (!forceBook.ContainsKey(currentSide))
                {
                    forceBook[currentSide] = new SortedSet<string>();
                }

                forceBook[currentSide].Add(name);
                Console.WriteLine($"{name} joins the {currentSide} side!");

                foreach (var sideToRemove in sides)
                {
                    if (sideToRemove != currentSide && forceBook.ContainsKey(sideToRemove))
                    {
                        forceBook[sideToRemove].Remove(name);
                    }
                }
            }
        }

        PrintForceBook(forceBook);
    }
    static void PrintForceBook(Dictionary<string, SortedSet<string>> forceBook)
    {
        foreach (var side in forceBook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            if (side.Value.Count == 0)
            {
                break;
            }

            Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

            foreach (var person in side.Value)
            {
                Console.WriteLine($"! {person}");
            }
        }
    }
}