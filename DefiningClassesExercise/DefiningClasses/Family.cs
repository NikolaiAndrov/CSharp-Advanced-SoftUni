using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family() 
        {
            People = new List<Person>();
        }
        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }

        public void PrintProperPeople()
        {
            foreach (Person person in People.OrderBy(x => x.Name))
            {
                if (person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }
}
