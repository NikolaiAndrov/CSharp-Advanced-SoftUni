namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var personInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var city = personInfo[2];

                Person person = new Person(name, age, city);
                people.Add(person);
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[personIndex];

            int matches = 0;
            int differentPeople = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    matches++;
                }
                else
                {
                    differentPeople++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {differentPeople} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}