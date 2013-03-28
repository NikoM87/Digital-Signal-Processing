﻿using System;
using System.IO;

using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class SignalSaverTest
    {
        [TestMethod]
        public void TestSignalSaver()
        {
            SignalSaver saver = new SignalSaver();
            Stream stream = new MemoryStream();

            Signal signal = new Signal();
            signal.Df = 0.045;
            signal.AddPoint( 1.2 );
            signal.AddPoint( 3.4 );
            signal.AddPoint( 5.6 );

            saver.Save( stream, signal );

            stream.Position = 0;
            BinaryReader reader = new BinaryReader( stream );

            Assert.AreEqual( SignalSaver.SignatureFile, reader.ReadUInt32() );
            Assert.AreEqual( 0, reader.ReadUInt16() );
            Assert.AreEqual( SignalSaver.VersionFormatFile, reader.ReadUInt16() );
            Assert.AreEqual( SignalSaver.ChankSignal, reader.ReadUInt16() );
            Assert.AreEqual( (UInt64) 36, reader.ReadUInt64() );
            Assert.AreEqual( 0.045, reader.ReadDouble() );
            Assert.AreEqual( 3, reader.ReadInt32() );
            Assert.AreEqual( 1.2, reader.ReadDouble() );
            Assert.AreEqual( 3.4, reader.ReadDouble() );
            Assert.AreEqual( 5.6, reader.ReadDouble() );
        }
    }
}