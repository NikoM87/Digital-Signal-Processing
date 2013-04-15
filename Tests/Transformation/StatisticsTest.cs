using DSP.Statictics;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Transformation
{
    [TestClass]
    public class StatisticsTest
    {
        [TestMethod]
        public void TestCorrelation()
        {
            double[] signal1 = {4, 2, -1, 3, -2, -6, -5, 4, 5};
            double[] signal2 = {-4, 1, 3, 7, 4, -2, -8, -2, 1};

            double r12 = Statictics.Correlation( signal1, signal2 );

            Assert.AreEqual( 5, r12 );
        }


        [TestMethod]
        public void TestCrossCorrelation()
        {
            double[] signal1 = {4, 2, -1, 3, -2, -4, 1, 3, 7, 4};
            double[] signal2 = {-4, 1, 3, 7, 4};

            double p12Delay1 = Statictics.CrossCorrelation( 1, signal1, signal2 );
            double p12Delay2 = Statictics.CrossCorrelation( 2, signal1, signal2 );
            double p12Delay3 = Statictics.CrossCorrelation( 3, signal1, signal2 );
            double p12Delay4 = Statictics.CrossCorrelation( 4, signal1, signal2 );
            double p12Delay5 = Statictics.CrossCorrelation( 5, signal1, signal2 );

            Assert.AreEqual( -0.3297, p12Delay1, 1E-4 );
            Assert.AreEqual( -0.2527, p12Delay2, 1E-4 );
            Assert.AreEqual( -0.0769, p12Delay3, 1E-4 );
            Assert.AreEqual( 0.6154, p12Delay4, 1E-4 );
            Assert.AreEqual( 1.0000, p12Delay5, 1E-4 );
        }
    }
}