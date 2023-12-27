using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Tyuiu.BakhtiyarovDR.Sprint7.Project.V15.Lib;

namespace Tyuiu.BakhtiyarovDR.Sprint7.Project.V15.Test
{
    [TestClass]
    public class DataServiceTest
    {
        DataService ds = new DataService();

        [TestMethod]
        public void SummDohod()
        {
            double[] array = { 1, 2, 3 };
            double res = ds.SummDohod(array);
            double wait = 6;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void MinDohod()
        {
            double[] array = { 12, 2, 3, 1 };
            double res = ds.MinDohod(array);
            double wait = 1;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void MaxDohod()
        {
            double[] array = { 12, 2, 3, 1 };
            double res = ds.MaxDohod(array);
            double wait = 12;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void AverageValue()
        {
            double[] array = { 2, 3, 1 };
            double res = ds.AverageValue(array);
            double wait = 2;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void CountDocument()
        {
            int[] array = { 2, 3, 1 };
            int res = ds.CountDocument(array);
            double wait = 3;
            Assert.AreEqual(wait, res);
        }
    }
}
