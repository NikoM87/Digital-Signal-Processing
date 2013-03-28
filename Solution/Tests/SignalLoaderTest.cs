using System;
using System.IO;

using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class SignalLoaderTest
    {
        private readonly BinaryWriter _binaryWriter;
        private readonly SignalLoader _loader;


        public SignalLoaderTest()
        {
            Stream stream = new MemoryStream();
            _loader = new SignalLoader( stream );
            _binaryWriter = new BinaryWriter( stream );
        }


        [TestMethod]
        public void LoadFileWithUnknownSignatureThrowException()
        {
            _binaryWriter.Write( (UInt64) 0 );
            _binaryWriter.BaseStream.Position = 0;

            try
            {
                _loader.LoadHeader();
                Assert.Fail();
            }
            catch ( SignatureException )
            {
            }
        }


        [TestMethod]
        public void LoadUnkownVersionOfFileThrowException()
        {
            _binaryWriter.Write( SignalSaver.SignatureFile );
            _binaryWriter.Write( (UInt16) 0 );
            _binaryWriter.Write( SignalSaver.VersionFormatFile + 1 );
            _binaryWriter.BaseStream.Position = 0;

            try
            {
                _loader.LoadHeader();
                Assert.Fail();
            }
            catch ( FileVesionException )
            {
            }
        }


        [TestMethod]
        public void LoadChunkHeader()
        {
            _binaryWriter.Write( (UInt16) 12345 );
            _binaryWriter.Write( (UInt64) 987654321 );
            _binaryWriter.BaseStream.Position = 0;

            BinaryReader reader = new BinaryReader( _binaryWriter.BaseStream );
            ChankReader chank = new ChankReader( reader );
            chank.Read();

            Assert.AreEqual( (UInt16) 12345, chank.Id );
            Assert.AreEqual( (UInt64) 987654321, chank.Size );
        }
    }
}