using System.Collections.Generic;
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

            var signal = new Signal();
            signal.Df = 0.045;
            signal.AddPoint( 1.2 );
            signal.AddPoint( 3.4 );
            signal.AddPoint( 5.6 );

            var saver = new SignalSaver( streams );
            saver.Save( new List<Signal> {signal} );

            streams.Position = 0;
            var loader = new SignalLoader( streams );
            List<Signal> loadedSignal = loader.Load();

            Assert.AreEqual( 0.045, loadedSignal[0].Df );
            Assert.AreEqual( signal.Length, loadedSignal[0].Length );
            Assert.AreEqual( 1.2, loadedSignal[0].Points[0] );
            Assert.AreEqual( 3.4, loadedSignal[0].Points[1] );
            Assert.AreEqual( 5.6, loadedSignal[0].Points[2] );
        }
    }
}