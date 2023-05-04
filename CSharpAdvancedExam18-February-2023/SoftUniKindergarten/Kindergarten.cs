using System.Collections.Generic;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }
        public int ChildrenCount
        {
            get { return Registry.Count; }
        }

        public bool AddChild(Child child)
        {
            if (Capacity > Registry.Count)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            string[] fullName = childFullName.Split();

            for (int i = 0; i < Registry.Count; i++)
            {
                if (Registry[i].FirstName == fullName[0] && Registry[i].LastName == fullName[1])
                {
                    Registry.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public Child GetChild(string childFullName)
        {
            string[] fullName = childFullName.Split();

            for (int i = 0; i < Registry.Count; i++)
            {
                if (Registry[i].FirstName == fullName[0] && Registry[i].LastName == fullName[1])
                {
                    return Registry[i];
                }
            }
            return null;
        }
        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            Registry.Sort(new ChildrenComparer());
            foreach (var child in Registry)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
