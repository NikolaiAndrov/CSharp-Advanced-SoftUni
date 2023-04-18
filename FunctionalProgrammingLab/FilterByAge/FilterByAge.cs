using System.Linq;
using System.Threading.Channels;

public class FilterByAge
{
    public static void Main()
    {
        List<Person> people = new List<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            Person person = new Person();
            person.Name = name;
            person.Age = age;
            people.Add(person);
        }

        string condition = Console.ReadLine();
        int ageTreshold = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        Func<Person, bool> filter = FilterByCondition(condition, ageTreshold);
        List<Person> filteredPeople = people.Where(filter).ToList();

        Action<Person> formatter = PrintPeopleByFormat(format);

        foreach (Person person in filteredPeople)
        {
            formatter(person);
        }
    }

    static Action<Person> PrintPeopleByFormat(string format)
    {
        if (format == "name age")
        {
            return p => Console.WriteLine($"{p.Name} - {p.Age}");
        }
        else if (format == "name")
        {
            return p => Console.WriteLine(p.Name);
        }
        else if (format == "age")
        {
            return p => Console.WriteLine(p.Age);
        }

        return null;
    }
    static Func<Person, bool> FilterByCondition(string condition, int ageTreshold)
    {
        if (condition == "older")
        {
            return p => p.Age >= ageTreshold;
        }
        else if (condition == "younger")
        {
            return p => p.Age < ageTreshold;
        }

        return null;
    }
    class Person
    {
        public string Name;
        public int Age;
    }
}