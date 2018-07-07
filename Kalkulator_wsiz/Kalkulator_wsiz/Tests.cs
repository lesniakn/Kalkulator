using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_wsiz
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Addition()
        {
            double result = 4;
            Assert.AreEqual(result, Operations.Addition(2, 2));
        }


        [TestMethod]
        public void Subtraction()
        {
            double result = 10;
            Assert.AreEqual(result, Operations.Subtraction(20, 10));
        }

        [TestMethod]
        public void Multiplication()
        {
            double result = 25;
            Assert.AreEqual(result, Operations.Multiplication(5, 5));
        }

        [TestMethod]
        public void Division()
        {
            double result = 5;
            Assert.AreEqual(result, Operations.Division(10, 2));
        }
    }
}
