using HW9.Concrete;
using NUnit.Framework;
using System.Linq;

namespace HW9.UnitTests
{
    [TestFixture]
    public class ParallelTotalCalculatorTests
    {
        private int[] _data;

        [SetUp]
        public void SetUp()
        {
            var lenght = 100;
            _data = new int[lenght];

            for (var i = 0; i < lenght; i++)
            {
                _data[i] = 1;
            }
        }

        [Test]
        public void SplitToChanks_FourChanks_ReturnChanks()
        {
            var chanks =  ChankHelper.SplitToChanks(_data, 4);

            Assert.AreEqual(4, chanks.Count());
            Assert.AreEqual(25, chanks[0].Count());
        }

        [Test]
        public void Sum_FourThreads_ReturnTotalSum()
        {
            var calculator = new ParallelTotalCalculator(4);
            var result = calculator.Sum(_data);

            Assert.AreEqual(100, result);
        }
    }
}
