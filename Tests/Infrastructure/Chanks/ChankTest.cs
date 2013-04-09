using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure.Chanks
{
    [TestClass]
    public class ChankTest
    {
        private readonly Chank _newChank;


        public ChankTest()
        {
            _newChank = new Chank();
        }


        [TestMethod]
        public void TestCreate()
        {
            Assert.AreEqual( 0, _newChank.Id );
            Assert.AreEqual( 0, _newChank.Size );
            Assert.AreEqual( null, _newChank.Data );
        }
    }
}