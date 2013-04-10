using System.Collections.Generic;

using DSP;
using DSP.Transformation;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;


namespace Tests.Transformation
{
    [TestClass]
    public class TransformationsTest
    {
        [TestMethod]
        public void CreateWithEnemerable()
        {
            var list = new List<ITransformation>();
            ITransformation l1 = new RemoveConstant();
            list.Add( l1 );
            ITransformation l2 = new RemoveConstant();
            list.Add( l2 );

            var transformations = new Transformations( list );

            Assert.AreEqual( l1, transformations[0] );
            Assert.AreEqual( l2, transformations[1] );
        }


        [TestMethod]
        public void Transformation()
        {
            var signal = new Signal();
            var mock1 = new Mock<ITransformation>();
            var mock2 = new Mock<ITransformation>();

            var transformations = new Transformations {mock1.Object, mock2.Object};

            transformations.TranformationSignal( signal );

            mock1.Verify( x => x.Execute( It.IsAny<Signal>() ), Times.Once() );
            mock2.Verify( x => x.Execute( It.IsAny<Signal>() ), Times.Once() );
        }
    }
}