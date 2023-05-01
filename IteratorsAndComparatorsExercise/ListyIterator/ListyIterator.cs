using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(params T[] items)
        {
            list = new List<T>(items);
            index = 0;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(list[index]);
            }
        }
        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }
        public bool HasNext()
        {
            return index + 1 < list.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
