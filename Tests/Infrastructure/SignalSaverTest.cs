using System;
using System.Collections.Generic;
using System.IO;

using DSP;
using DSP.Infrastructure;
using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure
{
    [TestClass]
    public sealed class SignalSaverTest : IDisposable
    {
        private readonly SignalSaver _saver;
        private readonly Signal _signal;
        private readonly Stream _stream;


        public SignalSaverTest()
        {
            _stream = new MemoryStream();
            _signal = new Signal();
            _signal.Df = 0.045;
            _signal.AddPoint( 1.2 );
            _signal.AddPoint( 3.4 );
            _signal.AddPoint( 5.6 );

            _saver = new SignalSaver( _stream );
        }


        public void Dispose()
        {
            _saver.Dispose();
            _stream.Dispose();
        }


        [TestMethod]
        public void TestSignalSaver()
        {
            _saver.Save( new List<Signal> {_signal} );
            _stream.Position = 0;

            var reader = new BinaryReader( _stream );
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


        [TestMethod]
        public void TestSignalSaveLoad()
        {
            _saver.Save( new List<Signal> {_signal} );
            _stream.Position = 0;

            var loader = new SignalLoader( _stream );
            List<Signal> loadedSignal = loader.Load();
            Assert.AreEqual( 0.045, loadedSignal[0].Df );
            Assert.AreEqual( 3, loadedSignal[0].Length );
            Assert.AreEqual( 1.2, loadedSignal[0].Points[0] );
            Assert.AreEqual( 3.4, loadedSignal[0].Points[1] );
            Assert.AreEqual( 5.6, loadedSignal[0].Points[2] );
        }
    }
}