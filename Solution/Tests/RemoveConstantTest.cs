﻿using DSP;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class RemoveConstantTest
    {
        [TestMethod]
        public void TestRemoveConstant()
        {
            Signal signal = new Signal();
            signal.Df = 0.1;
            signal.AddPoint( 1 );
            signal.AddPoint( 2 );
            signal.AddPoint( 3 );

            Transformation transformation = new RemoveConstant();
            Signal transformed = transformation.Execute( signal );

            Assert.AreEqual( signal.Df, transformed.Df );
            Assert.AreEqual( -1, transformed.Points[0] );
            Assert.AreEqual( 0, transformed.Points[1] );
            Assert.AreEqual( 1, transformed.Points[2] );
        }
    }
}