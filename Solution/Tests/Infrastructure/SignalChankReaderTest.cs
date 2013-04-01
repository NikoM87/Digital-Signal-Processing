using System;
using System.IO;

using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure
{
    [TestClass]
    public class SignalChankReaderTest
    {
        [TestMethod]
        public void LoadSignalChunk()
        {
            BinaryWriter binaryWriter = new BinaryWriter( new MemoryStream() );

            binaryWriter.Write( (UInt16) 1 );
            binaryWriter.Write( (UInt64) 16 );
            binaryWriter.BaseStream.Position = 0;

            BinaryReader reader = new BinaryReader( binaryWriter.BaseStream );
            ChankReader chank = new SignalChankReader( reader );

            Assert.AreEqual( (UInt16) 1, chank.Id );
            Assert.AreEqual( 16, chank.Size );
            Assert.AreEqual( 10, chank.Position );
        }
    }
}