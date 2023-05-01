using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class CustomStack<T> : IEnumerable<T>
    {
        Stack<T> stack;
        public CustomStack()
        {
            stack = new Stack<T>();
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                stack.Push(item);
            }
        }

        public void Pop()
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                stack.Pop();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in stack)
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
