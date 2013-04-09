using System.IO;

using DSP;
using DSP.Infrastructure;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure
{
    [TestClass]
    public class SignalLoadSaveTest
    {
        [TestMethod]
        public void TestSignalSaveLoad()
        {
            Stream streams = new MemoryStream();

            Signal signal = new Signal();
            signal.Df = 0.045;
            signal.AddPoint( 1.2 );
            signal.AddPoint( 3.4 );
            signal.AddPoint( 5.6 );

            SignalSaver saver = new SignalSaver( streams );
            saver.Save( signal );

            streams.Position = 0;
            SignalLoader loader = new SignalLoader( streams );
            Signal loadedSignal = loader.Load();

            Assert.AreEqual( 0.045, loadedSignal.Df );
            Assert.AreEqual( signal.Length, loadedSignal.Length );
            Assert.AreEqual( 1.2, loadedSignal.Points[0] );
            Assert.AreEqual( 3.4, loadedSignal.Points[1] );
            Assert.AreEqual( 5.6, loadedSignal.Points[2] );
        }
    }
}