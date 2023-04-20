public class PredicateParty
{
    public static void Main()
    {
        var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

        string input;

        while ((input = Console.ReadLine()) != "Party!")
        {
            var commandInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = commandInfo[0];

            if (command == "Double")
            {
                DoubleCriteria(commandInfo, names);
            }
            else if (command == "Remove")
            {
                RemoveCriteria(commandInfo, names); 
            }
        }

        PrintListOfPeople(names);
    }

    static void PrintListOfPeople(List<string> names)
    {
        if (names.Count > 0)
        {
            Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }
    static void RemoveCriteria(string[] commandInfo, List<string> names)
    {
        var criteria = commandInfo[1];

        if (criteria == "StartsWith")
        {
            var start = commandInfo[2];
            names.RemoveAll(name => name.StartsWith(start));
        }
        else if (criteria == "EndsWith")
        {
            var end = commandInfo[2];
            names.RemoveAll(name => name.EndsWith(end));
        }
        else if (criteria == "Length")
        {
            var len = int.Parse(commandInfo[2]);
            names.RemoveAll(name => name.Length == len);
        }
    }
    static void DoubleCriteria(string[] commandInfo, List<string> names)
    {
        var criteria = commandInfo[1];

        if (criteria == "StartsWith")
        {
            var start = commandInfo[2];
            var foundNames = names.FindAll(name => name.StartsWith(start));

            for (int i = 0; i < names.Count; i++)
            {
                var currentName = names[i];

                if (foundNames.Contains(currentName))
                {
                    names.Insert(i, currentName);
                    foundNames.Remove(currentName);
                }
            }
        }
        else if (criteria == "EndsWith")
        {
            var end = commandInfo[2];
            var foundNames = names.FindAll(name => name.EndsWith(end));

            for (int i = 0; i < names.Count; i++)
            {
                var currentName = names[i];

                if (foundNames.Contains(currentName))
                {
                    names.Insert(i, currentName);
                    foundNames.Remove(currentName);
                }
            }
        }
        else if (criteria == "Length")
        {
            var len = int.Parse(commandInfo[2]);
            var foundNames = names.FindAll(name => name.Length == len);

            for (int i = 0; i < names.Count; i++)
            {
                var currentName = names[i];

                if (foundNames.Contains(currentName))
                {
                    names.Insert(i, currentName);
                    foundNames.Remove(currentName);
                }
            }
        }
    }
}