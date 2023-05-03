using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count 
        {
            get { return Multiprocessor.Count; }
        }

        public void Add(CPU cpu)
        {
            if (Capacity > Multiprocessor.Count)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            for (int i = 0; i < Multiprocessor.Count; i++)
            {
                if (Multiprocessor[i].Brand == brand)
                {
                    Multiprocessor.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerfulCPU = null;
            double ghz = double.MinValue;

            foreach (CPU cpu in Multiprocessor)
            {
                if (cpu.Frequency > ghz)
                {
                    ghz = cpu.Frequency;
                    mostPowerfulCPU = cpu;
                }
            }

            return mostPowerfulCPU;
        }

        public CPU GetCPU(string brand)
        {
            foreach (CPU cpu in Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    return cpu;
                }
            }

            return null;
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (CPU cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
