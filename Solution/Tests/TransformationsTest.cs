using System.Collections.Generic;

using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;


namespace Tests
{
    [TestClass]
    public class TransformationsTest
    {
        [TestMethod]
        public void CreateWithEnemerable()
        {
            List<ITransformation> list = new List<ITransformation>();
            ITransformation l1 = new RemoveConstant();
            list.Add( l1 );
            ITransformation l2 = new RemoveConstant();
            list.Add( l2 );

            Transformations transformations = new Transformations( list );

            Assert.AreEqual( l1, transformations[0] );
            Assert.AreEqual( l2, transformations[1] );
        }


        [TestMethod]
        public void Transformation()
        {
            Signal signal = new Signal();
            Mock<ITransformation> mock1 = new Mock<ITransformation>();
            Mock<ITransformation> mock2 = new Mock<ITransformation>();

            Transformations transformations = new Transformations {mock1.Object, mock2.Object};

            transformations.TranformationSignal( signal );

            mock1.Verify( x => x.Execute( It.IsAny<Signal>() ), Times.Once() );
            mock2.Verify( x => x.Execute( It.IsAny<Signal>() ), Times.Once() );
        }
    }
}