using System.IO;

using DSP.Infrastructure.Chanks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Infrastructure
{
    [TestClass]
    public class ChankTest
    {
        private readonly StreamedChank _newChank;


        public ChankTest()
        {
            Stream stream = new MemoryStream();
            _newChank = new StreamedChank( stream );
        }


        [TestMethod]
        public void TestCreate()
        {
            Assert.AreEqual( 0, _newChank.Id );
            Assert.AreEqual( 0, _newChank.Size );
            Assert.AreEqual( 10, _newChank.Position );
            Assert.AreEqual( null, _newChank.Data );
        }
    }
}