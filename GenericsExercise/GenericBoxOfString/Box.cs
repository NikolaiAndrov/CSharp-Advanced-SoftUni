using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public int Compare(T element)
        {
            int count = 0;

            foreach (T item in list)
            {
                if (item.CompareTo(element) == 1)
                {
                    count++;
                }
            }

            return count;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            T item = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = item;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
