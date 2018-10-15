using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FPToolbox.Utility;

namespace FPToolbox.Test
{
    [TestClass]
    public class Utility
    {
        [TestMethod]
        public void OptionReturnsSome()
        {
            Option option = Option(5);

            int value = option.Match(0);

            Assert.AreEqual(5, value);
        }

        [TestMethod]
        public void OptionReturnsNone()
        {
            // can't pass null directly because it invalidates type inference
            // default of classes is null which is why we need this whole thing anyways.
            Option option = Option(default(Some<int>));

            int value = option.Match(0);

            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void SomeWorksForValueTypes()
        {
            Option option = Some(5);

            int value = option.Match(0);

            Assert.AreEqual(5, value);
        }

        class Square
        {
            public int Length;
        }

        [TestMethod]
        public void SomeWorksForReferenceTypes()
        {
            Square square = new Square() { Length = 3 };
            Option option = Some(square);

            Square value = option.Match(new Square());

            Assert.AreEqual(square, value);
            Assert.AreEqual(square.Length, value.Length);
        }

        [TestMethod]
        public void NoneWorks()
        {
            Option option = None();

            int value = option.Match(5);

            Assert.AreEqual(5, value);
        }
    }
}
