using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] items)
        {
            stones = new int[items.Length];
            int j = 0;

            for (int i = 0; i < items.Length; i++)
            {
                if (i % 2 == 0)
                {
                    stones[j] = items[i];
                    j++;
                }
            }

            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    stones[j] = items[i];
                    j++;
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
