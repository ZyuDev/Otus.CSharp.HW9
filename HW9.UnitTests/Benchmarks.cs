using HW9.Concrete;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace HW9.UnitTests
{
    [TestFixture]
    public class Benchmarks
    {
        [Test]
        [TestCase(100_000)]
        [TestCase(1_000_000)]
        [TestCase(10_000_000)]
        public void ConsequentialSumBenchmark(int size)
        {
            var data = DataGenerator.Generate(size, 10);

            var timer = new Stopwatch();

            timer.Start();

            var calculator = new ConsequentialTotalCalculator();
            var sum = calculator.Sum(data);

            timer.Stop();

            Console.WriteLine( $"size:{size}, ms: {timer.ElapsedMilliseconds}, sum: {sum}");

            Assert.Pass();
        }

        [Test]
        [TestCase(100_000)]
        [TestCase(1_000_000)]
        [TestCase(10_000_000)]
        public void PlinqSumBenchmark(int size)
        {
            var data = DataGenerator.Generate(size, 10);

            var timer = new Stopwatch();

            timer.Start();

            var calculator = new PlinqTotalCalculator();
            var sum = calculator.Sum(data);

            timer.Stop();

            Console.WriteLine($"size:{size}, ms: {timer.ElapsedMilliseconds}, sum: {sum}");

            Assert.Pass();
        }

        [Test]
        [TestCase(100_000)]
        [TestCase(1_000_000)]
        [TestCase(10_000_000)]
        public void ParallelSumBenchmark(int size)
        {
            var data = DataGenerator.Generate(size, 10);

            var timer = new Stopwatch();

            timer.Start();

            var calculator = new ParallelTotalCalculator(4);
            var sum = calculator.Sum(data);

            timer.Stop();

            Console.WriteLine($"size:{size}, ms: {timer.ElapsedMilliseconds}, sum: {sum}");

            Assert.Pass();
        }
    }
}
