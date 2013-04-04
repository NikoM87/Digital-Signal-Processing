using System;
using System.IO;

using DSP.Infrastructure.Chanks;
using DSP.Infrastructure.Chanks.Reader;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks.Reader
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
            ChankReader chankReader = new SignalChankReader( reader );
            Chank chank = chankReader.Chank;

            Assert.AreEqual( (UInt16) 1, chank.Id );
            Assert.AreEqual( 16, chank.Size );
        }
    }
}