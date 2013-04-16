using DSP;
using DSP.Algorithms;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Algorithms
{
    [TestClass]
    public class FastFourierTransformationTest
    {
        [TestMethod]
        public void TestFunction1()
        {
            var signal = new Complex[8];

            signal[0] = new Complex( 1 );
            signal[1] = new Complex( 0 );
            signal[2] = new Complex( 0 );
            signal[3] = new Complex( 0 );
            signal[4] = new Complex( 0 );
            signal[5] = new Complex( 0 );
            signal[6] = new Complex( 0 );
            signal[7] = new Complex( 0 );

            Complex[] spectrum = FastFourierTransformation.Calculate( signal, Direction.Forward );

            Assert.AreEqual( 8, spectrum.Length );
            Assert.AreEqual( +0.125, spectrum[0] );
            Assert.AreEqual( +0.125, spectrum[1] );
            Assert.AreEqual( +0.125, spectrum[2] );
            Assert.AreEqual( +0.125, spectrum[3] );
            Assert.AreEqual( +0.125, spectrum[4] );
            Assert.AreEqual( +0.125, spectrum[5] );
            Assert.AreEqual( +0.125, spectrum[6] );
            Assert.AreEqual( +0.125, spectrum[7] );
        }


        [TestMethod]
        public void TestFunction2()
        {
            var signal = new Complex[8];

            signal[0] = new Complex( 0 );
            signal[1] = new Complex( 1 );
            signal[2] = new Complex( 0 );
            signal[3] = new Complex( 0 );
            signal[4] = new Complex( 0 );
            signal[5] = new Complex( 0 );
            signal[6] = new Complex( 0 );
            signal[7] = new Complex( 0 );

            Complex[] spectrum = FastFourierTransformation.Calculate( signal, Direction.Forward );

            AssertComplexEqual( new Complex( +0.125, +0.000 ), spectrum[0] );
            AssertComplexEqual( new Complex( +0.088, -0.088 ), spectrum[1] );
            AssertComplexEqual( new Complex( +0.000, -0.125 ), spectrum[2] );
            AssertComplexEqual( new Complex( -0.088, -0.088 ), spectrum[3] );
            AssertComplexEqual( new Complex( -0.125, +0.000 ), spectrum[4] );
            AssertComplexEqual( new Complex( -0.088, +0.088 ), spectrum[5] );
            AssertComplexEqual( new Complex( +0.000, +0.125 ), spectrum[6] );
            AssertComplexEqual( new Complex( +0.088, +0.088 ), spectrum[7] );
        }


        private void AssertComplexEqual( Complex a, Complex b )
        {
            Assert.AreEqual( a.Re, b.Re, 1E-3 );
            Assert.AreEqual( a.Im, b.Im, 1E-3 );
        }
    }
}