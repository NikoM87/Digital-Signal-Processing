﻿using System;
using System.IO;

using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class SignalChankTest
    {
        [TestMethod]
        public void LoadSignalChunk()
        {
            BinaryWriter binaryWriter = new BinaryWriter( new MemoryStream() );

            binaryWriter.Write( (UInt16) 1 );
            binaryWriter.Write( (UInt64) 16 );
            binaryWriter.BaseStream.Position = 0;

            BinaryReader reader = new BinaryReader( binaryWriter.BaseStream );
            ChankReader chank = new SignalChank( reader );

            Assert.AreEqual( (UInt16) 1, chank.Id );
            Assert.AreEqual( (UInt64) 16, chank.Size );
        }
    }
}