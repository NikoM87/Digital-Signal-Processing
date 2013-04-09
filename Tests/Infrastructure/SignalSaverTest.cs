using System.Collections.Generic;
using System.IO;

using DSP;
using DSP.Infrastructure;
using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure
{
    [TestClass]
    public class SignalSaverTest
    {
        [TestMethod]
        public void TestSignalSaver()
        {
            Stream stream = new MemoryStream();
            SignalSaver saver = new SignalSaver( stream );

            Signal signal = new Signal();
            signal.Df = 0.045;
            signal.AddPoint( 1.2 );
            signal.AddPoint( 3.4 );
            signal.AddPoint( 5.6 );

            saver.Save( new List<Signal> {signal} );

            stream.Position = 0;
            BinaryReader reader = new BinaryReader( stream );

            Assert.AreEqual( SignalSaver.SignatureFile, reader.ReadUInt32() );
            Assert.AreEqual( 0, reader.ReadUInt16() );
            Assert.AreEqual( SignalSaver.VersionFormatFile, reader.ReadUInt16() );
            Assert.AreEqual( TypesChank.Array, (TypesChank) reader.ReadUInt16() );
            Assert.AreEqual( 52, reader.ReadInt64() );
            Assert.AreEqual( TypesChank.Signal, (TypesChank) reader.ReadUInt16() );
            Assert.AreEqual( 1, reader.ReadInt32() );
            Assert.AreEqual( TypesChank.Signal, (TypesChank) reader.ReadUInt16() );
            Assert.AreEqual( 36, reader.ReadInt64() );
            Assert.AreEqual( 0.045, reader.ReadDouble() );
            Assert.AreEqual( 3, reader.ReadInt32() );
            Assert.AreEqual( 1.2, reader.ReadDouble() );
            Assert.AreEqual( 3.4, reader.ReadDouble() );
            Assert.AreEqual( 5.6, reader.ReadDouble() );
        }
    }
}