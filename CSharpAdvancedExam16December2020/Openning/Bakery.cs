namespace BakeryOpenning
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);

            if (employee != null)
            {
                data.Remove(employee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee employee = null;
            int age = 0;

            foreach (Employee emp in data)
            {
                if (emp.Age > age)
                {
                    employee = emp;
                    age = emp.Age;
                }
            }

            return employee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (Employee emp in data)
            {
                sb.AppendLine(emp.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
