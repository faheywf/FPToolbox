using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FPToolbox.Test
{
	[TestClass]
    public class EnumerableExtensions
    {
		[TestMethod]
		public void MapSuccess()
        {
            List<int> lst = new List<int>();

			for(int i = 0; i < 100; i++)
            {
                lst.Add(i);
            }

            int square (int x) => x * x;

            List<int> squares = new List<int>(lst.Map(square));
			for(int i = 0; i < 100; i++)
            {
                Assert.AreEqual(square(i), squares[i]);
            }
        }

        [TestMethod]
        public void FilterSuccess()
        {
            List<int> lst = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                lst.Add(i);
            }

            bool isEven(int x) => x % 2 == 0;

            List<int> evens = new List<int>(lst.Filter(isEven));
            for (int i = 0; i < 100; i += 2)
            {
                Assert.AreEqual(i, evens[i/2]);
            }
        }

		[TestMethod]
		public void ReduceSuccess()
        {
            int sum(int acc, int x) => acc + x;

            List<int> lst = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                lst.Add(i);
            }

            int accumulator = 0;
			foreach(int n in lst)
            {
                accumulator += n;
            }

            Assert.AreEqual(accumulator, lst.Reduce(sum, 0));
        }
    }
}
