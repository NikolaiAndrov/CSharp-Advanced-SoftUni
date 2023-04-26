using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomStackClass
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        public CustomStack()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }
        public int Count { get; private set; }

        public void Push(int item)
        {
            if (this.items.Length == this.Count)
            {
                Enlarge();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public int Pop()
        {
            IsEmpty();

            int item = this.items[this.Count - 1];
            this.items[this.Count - 1] = 0;
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                Shrink();
            }

            return item;
        }
        public int Peek()
        {
            IsEmpty();
            int item = this.items[this.Count - 1];
            return item;
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        public void Clear()
        {
            IsEmpty();
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }
        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
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
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
