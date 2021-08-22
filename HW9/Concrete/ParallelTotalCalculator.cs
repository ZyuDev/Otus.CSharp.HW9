using HW9.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace HW9.Concrete
{
    public class ParallelTotalCalculator: ITotalCalculator
    {
        private readonly int _threadCount;

        private ConcurrentDictionary<string, long> _resultsTmp;

        public ParallelTotalCalculator(int threadCount)
        {
            _threadCount = threadCount;
            _resultsTmp = new ConcurrentDictionary<string, long>();
        }

        public long Sum(IEnumerable<int> data)
        {
            var result = 0L;

            _resultsTmp.Clear();

            var chanks = ChankHelper.SplitToChanks(data, _threadCount);
            var threads = new List<Thread>();

            foreach(var chank in chanks)
            {
                var thread = new Thread(new ParameterizedThreadStart(SumChank));
                thread.Name = $"_chank_calc_{Guid.NewGuid()}";

                threads.Add(thread);

                thread.Start(new { Name = thread.Name, Data = chank });
            }

            foreach(var thread in threads)
            {
                thread.Join();
            }

            foreach(var kvp in _resultsTmp)
            {
                result += kvp.Value;
            }

            return result;
        }

        private void SumChank(object args)
        {
            dynamic d = args;

            string threadName = d.Name;
            IEnumerable<int> data = d.Data;

            var calculator = new ConsequentialTotalCalculator();
            var result = calculator.Sum(data);

            _resultsTmp.TryAdd(threadName, result);

            Debug.WriteLine($"{threadName}, result: {result}");
        }

       
    }
}
