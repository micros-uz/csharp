using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04_Converter;

namespace ConverterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZeroTest()
        {
            int x = Converter.ToInt("0");

            Assert.AreEqual(0, x);
        }

        [TestMethod]
        public void OneTest()
        {
            int x = Converter.ToInt("6");

            Assert.AreEqual(6, x);  
        }

        [TestMethod]
        public void ManyDigitTest()
        {
            Assert.AreEqual(10, Converter.ToInt("10"));
            Assert.AreEqual(1000, Converter.ToInt("1000"));
            Assert.AreEqual(1000000, Converter.ToInt("1000000"));
            Assert.AreEqual(123456789, Converter.ToInt("123456789"));
        }
    }
}
