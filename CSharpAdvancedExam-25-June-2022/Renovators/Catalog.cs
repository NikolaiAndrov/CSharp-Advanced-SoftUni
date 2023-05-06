using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new Dictionary<string, Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count
        {
            get { return Renovators.Count; }
        }

        public Dictionary<string, Renovator> Renovators;

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null
                || renovator.Name == string.Empty || renovator.Type == string.Empty)
            {
                return $"Invalid renovator's information.";
            }

            if (NeededRenovators == Renovators.Count)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            Renovators.Add(renovator.Name, renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.ContainsKey(name))
            {
                Renovators.Remove(name);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            foreach (var renovator in Renovators)
            {
                if (renovator.Value.Type == type)
                {
                    Renovators.Remove(renovator.Key);
                    count++;
                }
            }
            return count;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.ContainsKey(name))
            {
                Renovators[name].Hired = true;
                return Renovators[name];
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovators = new List<Renovator>();

            foreach (var renovator in Renovators)
            {
                if (renovator.Value.Days >= days)
                {
                    renovators.Add(renovator.Value);
                }
            }

            return renovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in Renovators)
            {
                if (renovator.Value.Hired == false)
                {
                    sb.AppendLine(renovator.Value.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
