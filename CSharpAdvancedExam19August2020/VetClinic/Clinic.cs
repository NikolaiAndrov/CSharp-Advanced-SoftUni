namespace VetClinic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name);

            if (pet != null)
            {
                data.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = null;
            int age = 0;

            foreach (var item in data)
            {
                if (item.Age > age)
                {
                    age = item.Age;
                    pet = item;
                }
            }

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var item in data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
