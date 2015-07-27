using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2Library;

namespace Task2.Test
{
    [TestClass]
    public class GcdTest
    {
        [TestMethod]
        public void EuclidGCD_1071_462_Expected21()
        {
            int gcd = Gcd.GetEuclid(1071, 462);
            Assert.AreEqual(21, gcd);
        }

        [TestMethod]
        public void EuclidGCD_1071_462_21_Expected21()
        {
            int gcd = Gcd.GetEuclid(1071, 462, 21);
            Assert.AreEqual(21, gcd);
        }
        [TestMethod]
        public void EuclidGCD_1071_462_21_7Expected7()
        {
            int gcd = Gcd.GetEuclid(1071, 462, 21, 7);
            Assert.AreEqual(7, gcd);
        }

        [TestMethod]
        public void EuclidGCD_Minus21_Minus7Expected_Minus7()
        {
            int gcd = Gcd.GetEuclid(-21, -7);
            Assert.AreEqual(-7, gcd);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EuclidGCD_1071ExpectedException()
        {
            Gcd.GetEuclid();
        }


        //Stein
        [TestMethod]
        public void SteinGCD_1071_462_Expected21()
        {
            int gcd = Gcd.GetStein(1071, 462);
            Assert.AreEqual(21, gcd);
        }

        [TestMethod]
        public void SteinGCD_1071_462_21Expected21()
        {
            int gcd = Gcd.GetStein(1071, 462, 21);
            Assert.AreEqual(21, gcd);
        }

        [TestMethod]
        public void SteinGCD_1071_462_21_7Expected7()
        {
            int gcd = Gcd.GetStein(1071, 462, 21, 7);
            Assert.AreEqual(7, gcd);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SteinGCD_1071ExpectedException()
        {
            Gcd.GetStein(1071);
        }
    }
}
