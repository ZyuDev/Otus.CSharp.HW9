using HW9.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.Concrete
{
    public class ConsequentialTotalCalculator : ITotalCalculator
    {
        public long Sum(IEnumerable<int> data)
        {
            long result = 0;

            foreach (var val in data)
            {
                result += val;
            }

            return result;
        }
    }
}
