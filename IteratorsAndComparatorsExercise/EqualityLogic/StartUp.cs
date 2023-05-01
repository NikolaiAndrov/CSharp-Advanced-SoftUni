namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {
            HashSet<Person> hashset = new HashSet<Person>();
            SortedSet<Person> sortedset = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                hashset.Add(person);
                sortedset.Add(person);
            }

            Console.WriteLine(hashset.Count);
            Console.WriteLine(sortedset.Count);
        }
    }
}