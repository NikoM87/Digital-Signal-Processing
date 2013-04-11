using DSP;
using DSP.Transformation;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Transformation
{
    [TestClass]
    public class RemoveConstantTest
    {
        private readonly Signal _signal;
        private readonly ITransformation _transformation;


        public RemoveConstantTest()
        {
            _signal = new Signal();
            _signal.Df = 0.1;
            _signal.AddPoint( 1 );
            _signal.AddPoint( 2 );
            _signal.AddPoint( 3 );

            _transformation = new RemoveConstant();
        }


        [TestMethod]
        public void TestRemoveConstant()
        {
            Signal transformed = _transformation.Execute( _signal );

            Assert.AreEqual( _signal.Df, transformed.Df );
            Assert.AreEqual( -1, transformed.Points[0] );
            Assert.AreEqual( 0, transformed.Points[1] );
            Assert.AreEqual( 1, transformed.Points[2] );
        }
    }
}