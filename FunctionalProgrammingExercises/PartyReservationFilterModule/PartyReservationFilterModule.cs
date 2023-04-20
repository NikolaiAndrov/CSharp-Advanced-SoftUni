public class PartyReservationFilterModule
{
    public static void Main()
    {
        var guests = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var filters = new List<string>();

        AddFilters(filters);
        ApplyFilters(filters, guests);

        Console.WriteLine(string.Join(" ", guests));
    }

    static void ApplyFilters(List<string> filters, List<string> guests)
    {
        foreach (var filter in filters)
        {
            var filterInfo = filter.Split(":");
            var action = filterInfo[0];

            if (action == "Starts with")
            {
                var start = filterInfo[1];
                guests.RemoveAll(name => name.StartsWith(start));
            }
            else if (action == "Ends with")
            {
                var end = filterInfo[1];
                guests.RemoveAll(name => name.EndsWith(end));
            }
            else if (action == "Length")
            {
                var len = int.Parse(filterInfo[1]);
                guests.RemoveAll(name => name.Length == len);
            }
            else if (action == "Contains")
            {
                var content = filterInfo[1];
                guests.RemoveAll(name => name.Contains(content));
            }
        }
    }
    static void AddFilters(List<string> filters)
    {
        string input;

        while ((input = Console.ReadLine()) != "Print")
        {
            var filterInfo = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
            var command = filterInfo[0];
            var filter = $"{filterInfo[1]}:{filterInfo[2]}";

            if (command == "Add filter")
            {
                filters.Add(filter);
            }
            else if (command == "Remove filter")
            {
                filters.Remove(filter);
            }
        }
    }
}