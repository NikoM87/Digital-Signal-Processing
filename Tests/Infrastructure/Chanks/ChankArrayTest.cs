using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks
{
    [TestClass]
    public class ChankArrayTest
    {
        private readonly ArrayChank _array;


        public ChankArrayTest()
        {
            _array = new ArrayChank( TypesChank.Unknown );
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
            var newChank1 = new Chank();
            var newChank2 = new Chank();

            _array.Add( newChank1 );
            _array.Add( newChank2 );

            Assert.AreEqual( 2, _array.Length );
            Assert.AreEqual( newChank1, _array[0] );
            Assert.AreEqual( newChank2, _array[1] );
        }
    }
}