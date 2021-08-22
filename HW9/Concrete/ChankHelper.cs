using System.Collections.Generic;
using System.Linq;

namespace HW9.Concrete
{
    public class ChankHelper
    {
        public static List<IEnumerable<int>> SplitToChanks(IEnumerable<int> data, int chanksCount)
        {
            var chanks = new List<IEnumerable<int>>();

            if (chanksCount < 1)
            {
                chanks.Add(data);
                return chanks;
            }

            var chankSize = data.Count() / chanksCount;

            var currentChank = new int[chankSize];
            chanks.Add(currentChank);

            var i = 0;
            foreach (var val in data)
            {

                if (i > currentChank.Length - 1)
                {
                    chanks.Add(currentChank);
                    currentChank = new int[chankSize];
                    i = 0;
                }

                currentChank[i] = val;


                i++;
            }

            return chanks;
        }
    }
}
