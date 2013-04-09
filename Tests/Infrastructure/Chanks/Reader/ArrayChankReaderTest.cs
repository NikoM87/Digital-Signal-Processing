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

            ArrayChankWriter saver = new ArrayChankWriter( binaryWriter );
            saver.Write( new ArrayChank( TypesChank.Signal )
            {
                new SignalChank( new Signal() ),
                new SignalChank( new Signal() )
            } );

            binaryWriter.BaseStream.Position = 0;

            BinaryReader reader = new BinaryReader( binaryWriter.BaseStream );
            ChankReader chankReader = new ArrayChankReader( reader );
            ArrayChank list = (ArrayChank) chankReader.ReadData();

            Assert.AreEqual( 2, list.Length );
            Assert.AreEqual( (ushort) TypesChank.Signal, list[0].Id );
            Assert.AreEqual( 12, list[0].Size );
            Assert.AreEqual( (ushort) TypesChank.Signal, list[1].Id );
            Assert.AreEqual( 12, list[1].Size );
        }
    }
}