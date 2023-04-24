namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }

           // Person oldestPerson = family.GetOldestMember();
           // Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

            family.PrintProperPeople();
        }
    }
}