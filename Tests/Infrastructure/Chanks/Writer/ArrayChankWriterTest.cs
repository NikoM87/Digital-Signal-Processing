using System.IO;

using DSP;
using DSP.Infrastructure.Chanks;
using DSP.Infrastructure.Chanks.Reader;
using DSP.Infrastructure.Chanks.Writer;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks.Writer
{
    [TestClass]
    public class ArrayChankWriterTest
    {
        [TestMethod]
        public void ArrayChankSaveAndLoad()
        {
            var writer = new BinaryWriter( new MemoryStream() );
            var arrayWriter = new ArrayChankWriter( writer );

            var signals = new ArrayChank( TypesChank.Signal )
            {
                new SignalChank( new Signal
                {
                    Df = 0.1
                } ),
                new SignalChank( new Signal
                {
                    Df = 0.2
                } )
            };

            arrayWriter.Write( signals );
            writer.BaseStream.Position = 0;

            var arrayReader = new ArrayChankReader( new BinaryReader( writer.BaseStream ) );
            var readedSignals = (ArrayChank) arrayReader.ReadData();

            var s1 = (Signal) readedSignals[0].Data;
            var s2 = (Signal) readedSignals[1].Data;

            Assert.AreEqual( 0.1, s1.Df );
            Assert.AreEqual( 0.2, s2.Df );
        }
    }
}