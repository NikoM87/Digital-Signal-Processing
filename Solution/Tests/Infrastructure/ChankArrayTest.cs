using System.IO;

using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class ChankArrayTest
    {
        private readonly ChankArray _array;


        public ChankArrayTest()
        {
            Stream stream = new MemoryStream();
            _array = new ChankArray( stream );
        }


        [TestMethod]
        public void TestChankArrayCreate()
        {
            Assert.AreEqual( 2, _array.Id );
            Assert.AreEqual( 0, _array.Length );
        }


        [TestMethod]
        public void TestAddChank()
        {
            Chank newChank = new ChankArray( new MemoryStream() );

            _array.Add( newChank );
            _array.Add( newChank );

            Assert.AreEqual( 2, _array.Length );
        }
    }
}