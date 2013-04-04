using System;
using System.Collections.Generic;
using System.IO;

using DSP;
using DSP.Infrastructure.Chanks;
using DSP.Infrastructure.Chanks.Reader;
using DSP.Infrastructure.Chanks.Writer;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks.Reader
{
    [TestClass]
    public class ArrayChankReaderTest
    {
        [TestMethod]
        public void LoadArrayChank()
        {
            BinaryWriter binaryWriter = new BinaryWriter( new MemoryStream() );
            binaryWriter.Write( (UInt16) TypesChank.Array );
            binaryWriter.Write( (Int64) 0 );

            Signal signal = new Signal();

            binaryWriter.Write( (UInt16) TypesChank.Signal );
            binaryWriter.Write( 2 );
            SignalChankWriter saver = new SignalChankWriter( binaryWriter );
            saver.Write( signal );
            saver.Write( signal );

            binaryWriter.BaseStream.Position = 0;

            BinaryReader reader = new BinaryReader( binaryWriter.BaseStream );
            ChankReader chankReader = new ArrayChankReader( reader );
            List<Chank> list = (List<Chank>) chankReader.ReadData();

            Assert.AreEqual( 2, list.Count );
            Assert.AreEqual( (ushort) TypesChank.Signal, list[0].Id );
            Assert.AreEqual( 12, list[0].Size );
            Assert.AreEqual( (ushort) TypesChank.Signal, list[1].Id );
            Assert.AreEqual( 12, list[1].Size );
        }
    }
}