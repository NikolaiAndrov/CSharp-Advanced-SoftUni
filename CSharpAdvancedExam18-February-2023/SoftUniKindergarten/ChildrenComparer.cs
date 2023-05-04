using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKindergarten
{
    internal class ChildrenComparer : IComparer<Child>
    {
        public int Compare(Child x, Child y)
        {
            int result = y.Age.CompareTo(x.Age);

            if (result == 0)
            {
                result = x.LastName.CompareTo(y.LastName);
            }

            if (result == 0)
            {
                result = x.FirstName.CompareTo(y.FirstName);
            }

            return result;
        }
    }
}
