using DSP;
using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks
{
    [TestClass]
    public class SignalChankTest
    {
        private readonly SignalChank _signalChank;


        public SignalChankTest()
        {
            _signalChank = new SignalChank();
        }


        [TestMethod]
        public void TestSignalChankCreate()
        {
            Assert.AreEqual( 1, _signalChank.Id );
            Assert.AreEqual( 0, _signalChank.Size );
            Assert.AreEqual( null, _signalChank.Data );
        }


        [TestMethod]
        public void TestSignalChankCreateWithSignal()
        {
            var signal = new Signal();

            var signalChank = new SignalChank( signal );

            Assert.AreEqual( signal, signalChank.Data );
        }
    }
}