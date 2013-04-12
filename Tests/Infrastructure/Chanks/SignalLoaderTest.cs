using System;
using System.IO;

using DSP.Infrastructure;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks
{
    [TestClass]
    public sealed class SignalLoaderTest : IDisposable
    {
        private readonly BinaryWriter _binaryWriter;
        private readonly SignalLoader _loader;


        public SignalLoaderTest()
        {
            Stream stream = new MemoryStream();
            _loader = new SignalLoader( stream );
            _binaryWriter = new BinaryWriter( stream );
        }


        public void Dispose()
        {
            _loader.Dispose();
            _binaryWriter.Dispose();
        }


        [TestMethod]
        public void LoadFileWithUnknownSignatureThrowException()
        {
            _binaryWriter.Write( (UInt64) 0 );
            _binaryWriter.BaseStream.Position = 0;

            try
            {
                _loader.Load();
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
                _loader.Load();
                Assert.Fail();
            }
            catch ( FileVesionException )
            {
            }
        }
    }
}