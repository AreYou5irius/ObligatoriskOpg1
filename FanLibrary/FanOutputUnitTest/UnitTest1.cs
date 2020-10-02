using System;
using FanLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FanOutputUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        private FanOutput fan;


        [TestInitialize]
        public void SetupFanOutput()
        {
            fan = new FanOutput();
        }

        [TestMethod]
        public void TestCheckId()
        {
            fan.Id = 120;
            Assert.AreEqual(120, fan.Id);
            fan.Id = 200;
            Assert.AreEqual(200, fan.Id);

            try
            {
                fan.Id = -200;
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Id skal være et positivt tal", e.Message);

            }
        }

        [TestMethod]
        public void TestCheckNavn()
        {
            fan.Navn = "AZ";
            Assert.AreEqual("AZ", fan.Navn);
            fan.Navn = "AZK";
            Assert.AreEqual("AZK", fan.Navn);

            try
            {
                fan.Navn = "A";
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Navn skal være på 2 eller flere bogstaver", e.Message);

            }
        }

        [TestMethod]
        public void TestCheckTemp()
        {
            fan.Temp = 15;
            Assert.AreEqual(15, fan.Temp);

            fan.Temp = 20;
            Assert.AreEqual(20, fan.Temp);

            fan.Temp = 25;
            Assert.AreEqual(25, fan.Temp);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForHøjTemp()
        {
            fan.Temp = 29;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForLavTemp()
        {
            fan.Temp = 12;

        }



        [TestMethod]
        public void TestCheckFugt()
        {
            fan.Fugt = 30;
            Assert.AreEqual(30, fan.Fugt);

            fan.Fugt = 55;
            Assert.AreEqual(55, fan.Fugt);

            fan.Fugt = 80;
            Assert.AreEqual(80, fan.Fugt);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForHøjFugt()
        {
            fan.Fugt = 81;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestForLavFugt()
        {
            fan.Fugt = 24;
        }

    }
}