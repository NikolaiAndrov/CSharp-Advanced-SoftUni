using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string city;

        public Person(string name, int age, string city)
        {
            this.name = name;
            this.age = age;
            this.city = city;
        }

        public int CompareTo(Person other)
        {
            int result = name.CompareTo(other.name);

            if (result == 0)
            {
                result = age.CompareTo(other.age);
            }

            if (result == 0)
            {
                result = city.CompareTo(other.city);
            }

            return result;
        }
    }
}
