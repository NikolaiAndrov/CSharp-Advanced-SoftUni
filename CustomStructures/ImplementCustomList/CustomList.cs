using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementCustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }
            set
            {
                CheckIndex(index);
                items[index] = value;
            }
        }
        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            CheckIndex(index);
            var item = this.items[index];
            this.items[index] = default;
            this.Shift(index);

            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }
        public void Insert(int index, int item)
        {
            CheckIndex(index);

            if (this.Count == this.items.Length)
            {
                Resize();
            }

            ShiftToRight(index);
            this.items[index] = item;
            this.Count++;
        }
        public bool Contains(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndex(firstIndex);
            CheckIndex(secondIndex);
            var tempElement = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempElement;
        }
        public int Find(Predicate<int> condition)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (condition(this.items[i]))
                {
                    return this.items[i];
                }
            }
            return -1;
        }
        public int FindLast(Predicate<int> condition)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (condition(this.items[i]))
                {
                    return this.items[i];
                }
            }
            return -1;
        }
        public int IndexOf(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
        public int LastIndexOf(int item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Select(Func<int, int> function)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = function(this.items[i]);
            }
        }
        public int Sum()
        {
            int sum = 0;

            for (int i = 0; i < this.Count; i++)
            {
                sum += this.items[i];
            }

            return sum;
        }
        public CustomList FindAll(Predicate<int> condition)
        {
            CustomList matches = new CustomList();

            for (int i = 0; i < this.Count; i++)
            {
                if (condition(this.items[i]))
                {
                    matches.Add(this.items[i]);
                }
            }
            return matches;
        }
        public void Clear()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }
        public bool Any(Predicate<int> condition)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (condition(this.items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                var tempElement = this.items[i];
                this.items[i] = this.items[this.Count - 1 - i];
                this.items[this.Count - 1 - i] = tempElement;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this.items[i] + " ");
            }
            return sb.ToString().TrimEnd();
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
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
