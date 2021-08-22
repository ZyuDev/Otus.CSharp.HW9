using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.Concrete
{
    public class DataGenerator
    {
        public static IEnumerable<int> Generate(int size, int maxValue)
        {
            int[] arr = new int[size];

            var rnd = new Random();

            for (var i = 0; i < size; i++){

                 arr[i] = rnd.Next(maxValue);
            }

            return arr;
        }
    }
}
