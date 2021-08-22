using HW9.Concrete;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9.UnitTests
{
    [TestFixture]
    public class DataGeneratorTests
    {
        [Test]
        public void Generate_ReturnRandomData()
        {
            var count = 5;
            var data = DataGenerator.Generate(count, 10);

            foreach(var val in data)
            {
                Console.Write(val);
                Console.Write(" ");
            }

            Assert.AreEqual(count, data.Count());
        }
    }
}
