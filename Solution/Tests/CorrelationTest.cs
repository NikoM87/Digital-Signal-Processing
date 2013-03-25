using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSP;


namespace Tests
{
    [TestClass]
    public class CorrelationTest
    {
        private readonly Correlation _correlation;


        public CorrelationTest()
        {
            _correlation = new Correlation();
        }


        [TestMethod]
        public void TestCorrelation()
        {
            double[] signal1 = {4, 2, -1, 3, -2, -6, -5, 4, 5};
            double[] signal2 = {-4, 1, 3, 7, 4, -2, -8, -2, 1};

            double c = _correlation.Execute( signal1, signal2 );

            Assert.AreEqual( 5, c );
        }
    }
}
