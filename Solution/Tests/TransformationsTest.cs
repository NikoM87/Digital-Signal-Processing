using System.Collections.Generic;

using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class TransformationsTest
    {
        [TestMethod]
        public void CreateWithEnemerable()
        {
            List<Transformation> list = new List<Transformation>();
            Transformation l1 = new RemoveConstant();
            list.Add( l1 );
            Transformation l2 = new RemoveConstant();
            list.Add( l2 );
            
            Transformations transformations = new Transformations( list );

            Assert.AreEqual( l1, transformations[0] );
            Assert.AreEqual( l2, transformations[1] );
        }
    }
}