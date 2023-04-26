using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomQueueClass
{
    public class CustomQueue
    {
        private const int initialCapacity = 4;
        private const int firstElement = 0;
        private int[] items;

        public CustomQueue()
        {
            this.items = new int[initialCapacity];
            this.Count = 0;
        }
        public int Count { get; private set; }
        public void Enqueue(int item)
        {
            if (this.Count == this.items.Length)
            {
                Enlarge();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public int Dequeue()
        {
            IsEmpty();
            int item = this.items[firstElement];
            SwitchElements();
            this.Count--;
            return item;
        }
        public int Peek()
        {
            IsEmpty();
            int item = this.items[firstElement];
            return item;
        }
        public void Clear()
        {
            IsEmpty();
            this.items = new int[initialCapacity];
            this.Count = 0;
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
        }
        private void SwitchElements()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
        }
        private void Enlarge()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
