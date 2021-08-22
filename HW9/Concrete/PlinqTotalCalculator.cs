using HW9.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.Concrete
{
    public class PlinqTotalCalculator : ITotalCalculator
    {
        public long Sum(IEnumerable<int> data)
        {
            var result = data.AsParallel().Sum();

            return result;
        }
    }
}
