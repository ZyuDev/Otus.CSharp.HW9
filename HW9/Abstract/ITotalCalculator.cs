using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.Abstract
{
    public interface ITotalCalculator
    {
        long Sum(IEnumerable<int> data);
    }
}
