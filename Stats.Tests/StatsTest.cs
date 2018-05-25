using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Stats.Tests
{
    [TestClass]
    public class StatsTest
    {
        private readonly double[] data = new double[3] { 1.0, 1.2, 2.0 };

        [TestMethod]
        public void MeanTest()
        {
            Assert.AreEqual(1.4, data.Mean(), 0.0001);
        }

        [TestMethod]
        public void VarianceTest()
        {
            Assert.AreEqual(0.18666, data.Variance(VarianceType.Population), 0.0001);
            Assert.AreEqual(0.28, data.Variance(VarianceType.Sample), 0.0001);
        }

        [TestMethod]
        public void StandardDeviationTest()
        {
            Assert.AreEqual(0.43204, data.StandardDeviation(VarianceType.Population), 0.0001);
            Assert.AreEqual(0.52915, data.StandardDeviation(VarianceType.Sample), 0.0001);
        }

        [TestMethod]
        public void TestShouldThrowAnException()
        {
            var input = new double[0];

            Exception ex;

            ex = Assert.ThrowsException<InvalidOperationException>(() => input.Mean());
            Assert.AreEqual(Consts.EMPTY_ARRAY, ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() => input.Variance(VarianceType.Sample));
            Assert.AreEqual(Consts.EMPTY_ARRAY, ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() => input.Variance(VarianceType.Population));
            Assert.AreEqual(Consts.EMPTY_ARRAY, ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() => input.StandardDeviation(VarianceType.Sample));
            Assert.AreEqual(Consts.EMPTY_ARRAY, ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() => input.StandardDeviation(VarianceType.Population));
            Assert.AreEqual(Consts.EMPTY_ARRAY, ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() => new double[] { 0.1 }.Variance(VarianceType.Sample));
            Assert.AreEqual(Consts.INVALID_SAMPLE_FOR_VARIANCE, ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() => new double[] { 0.1 }.StandardDeviation(VarianceType.Sample));
            Assert.AreEqual(Consts.INVALID_SAMPLE_FOR_VARIANCE, ex.Message);
        }
    }
}
