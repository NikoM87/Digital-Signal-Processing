using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class ConvolutionTest
    {
        [TestMethod]
        public void TestConvolution()
        {
            var conv = new Convolution();

            double[] x = {1, 2, 3, 4, 1, 2, 3, 4};
            double[] h = {4, 3, 2, 1};
            double[] y = conv.Execute( x, h );

            Assert.AreEqual( 24, y[0] );
            Assert.AreEqual( 22, y[1] );
            Assert.AreEqual( 24, y[2] );
            Assert.AreEqual( 30, y[3] );
        }
    }
}