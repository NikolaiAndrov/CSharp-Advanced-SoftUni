public class SoftUniParty
{
    public static void Main()
    {
        HashSet<string> guests = new HashSet<string>();
       
        string input;
        bool party = false;

        while ((input = Console.ReadLine()) != "END")
        {
            if (input == "PARTY")
            {
                party = true;
                continue;
            }

            if (party)
            {
                guests.Remove(input);
            }
            else
            {
                guests.Add(input);
            }
        }

        Console.WriteLine(guests.Count);

        foreach (var guest in guests)
        {
            if (char.IsDigit(guest[0]))
            {
                Console.WriteLine(guest);
            }
        }

        foreach (var guest in guests)
        {
            if (char.IsLetter(guest[0]))
            {
                Console.WriteLine(guest);
            }
        }
    }
}