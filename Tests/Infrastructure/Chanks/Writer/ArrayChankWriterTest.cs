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
            BinaryWriter writer = new BinaryWriter( new MemoryStream() );
            ArrayChankWriter arrayWriter = new ArrayChankWriter( writer );

            ArrayChank signals = new ArrayChank( TypesChank.Signal );
            signals.Add( new SignalChank( new Signal
            {
                Df = 0.1
            } ) );
            signals.Add( new SignalChank( new Signal
            {
                Df = 0.2
            } ) );

            arrayWriter.Write( signals );
            writer.BaseStream.Position = 0;

            ArrayChankReader arrayReader = new ArrayChankReader( new BinaryReader( writer.BaseStream ) );
            ArrayChank readedSignals = (ArrayChank) arrayReader.ReadData();

            Signal s1 = (Signal) readedSignals[0].Data;
            Signal s2 = (Signal) readedSignals[1].Data;

            Assert.AreEqual( 0.1, s1.Df );
            Assert.AreEqual( 0.2, s2.Df );
        }
    }
}