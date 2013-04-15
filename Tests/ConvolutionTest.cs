using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class ConvolutionTest
    {
        private readonly double[] _x1 = {1, 2, 3, 4, 1, 2, 3, 4};
        private readonly double[] _x2 = {4, 3, 2, 1};


        [TestMethod]
        public void TestConvolution()
        {
            double[] y = Convolution.Execute( _x1, _x2 );

            Assert.AreEqual( 24, y[0] );
            Assert.AreEqual( 22, y[1] );
            Assert.AreEqual( 24, y[2] );
            Assert.AreEqual( 30, y[3] );
        }
    }
}