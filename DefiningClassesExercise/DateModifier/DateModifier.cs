using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {
        public int GetDaysDifference(string firstDate, string secondDate)
        {
            DateTime date1 = DateTime.Parse(firstDate);
            DateTime date2 = DateTime.Parse(secondDate);
            int days = Math.Abs((date1 - date2).Days);
            return days;
        }
    }
}
