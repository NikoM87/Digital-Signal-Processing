using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class SignalTest
    {
        private readonly Signal _signal;


        public SignalTest()
        {
            _signal = new Signal();
        }


        [TestMethod]
        public void TestCreation()
        {
            Assert.AreEqual( _signal.Df, 0 );
            Assert.AreEqual( _signal.Length, 0 );
        }


        [TestMethod]
        public void TestAddPoints()
        {
            _signal.AddPoint( 1.1 );
            _signal.AddPoint( 2.2 );

            Assert.AreEqual( _signal.ToArray[0], 1.1 );
            Assert.AreEqual( _signal.ToArray[1], 2.2 );
            Assert.AreEqual( _signal.Length, 2 );
        }
    }
}
