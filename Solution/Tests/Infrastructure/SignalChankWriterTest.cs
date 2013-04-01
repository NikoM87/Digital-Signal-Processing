using System.IO;

using DSP;
using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure
{
    [TestClass]
    public class SignalChankWriterTest
    {
        private readonly BinaryWriter _writer = new BinaryWriter( new MemoryStream() );


        [TestMethod]
        public void TestSignalSave()
        {
            Signal signal = new Signal();
            signal.Df = 0.01;
            signal.AddPoint( 1.3 );
            signal.AddPoint( 2.4 );

            ChankWriter chank = new SignalChankWriter( _writer );
            chank.Write( signal );

            Assert.AreEqual( 1, chank.Id );
            Assert.AreEqual( 28, chank.Size );
            Assert.AreEqual( 10, chank.Position );
        }


        [TestMethod]
        public void TestPosition()
        {
            Signal signal = new Signal();
            signal.Df = 0.01;
            signal.AddPoint( 1.3 );
            signal.AddPoint( 2.4 );

            ChankWriter chank = new SignalChankWriter( _writer );
            chank.Write( signal );

            Assert.AreEqual( 1, chank.Id );
            Assert.AreEqual( 28, chank.Size );
            Assert.AreEqual( 10, chank.Position );

            chank = new SignalChankWriter( _writer );
            chank.Write( signal );

            Assert.AreEqual( 1, chank.Id );
            Assert.AreEqual( 28, chank.Size );
            Assert.AreEqual( 48, chank.Position );
        }


        [TestMethod]
        public void TestSize()
        {
            Signal signal1 = new Signal();
            signal1.Df = 0.01;
            signal1.AddPoint( 1.3 );
            signal1.AddPoint( 2.4 );

            Signal signal2 = new Signal();
            signal2.Df = 0.01;
            signal2.AddPoint( 1.3 );
            signal2.AddPoint( 2.4 );
            signal2.AddPoint( 3.6 );

            ChankWriter chank1 = new SignalChankWriter( _writer );
            chank1.Write( signal1 );

            ChankWriter chank2 = new SignalChankWriter( _writer );
            chank2.Write( signal2 );

            Assert.AreEqual( 28, chank1.Size );
            Assert.AreEqual( 36, chank2.Size );
        }
    }
}