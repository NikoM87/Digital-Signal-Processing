using DSP.Statictics;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class CorrelationTest
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
        public void TestDelayedCorrelation()
        {
            double[] signal1 = {4, 2, -1, 3, -2, -6, -5, 4, 5};
            double[] signal2 = {-4, 1, 3, 7, 4, -2, -8, -2, -1};

            double r12 = Statictics.Correlation( 3, signal1, signal2 );

            Assert.AreEqual( 2.667, r12, 1E-3 );
        }


        [TestMethod]
        public void TestCrossCorrelation()
        {
            //double[] x1 = { 03, 05, 05, 05, 02, 0.5, 0.25, 0 };
            //double[] x2 = { 01, 01, 01, 01, 01, 0.0, 0.00, 0 };
            //double[] x3 = { 09, 15, 15, 15, 06, 1.5, 0.75,0 };
            //double[] x4 = { 02, 02, 02, 02, 02, 0.0, 0.00,0 };

            //double r12_0 = Statictics.Correlation( 0, x3, x4 );
            //double edge = Statictics.EdgeEffect( 1, x4.Length, r12_0 );
            //double r12_1 = Statictics.Correlation( 1, x3, x4 );
            //double r12_1_edge = r12_1 + edge;

            //Assert.AreEqual( 2, r12_1_edge );
        }
    }
}