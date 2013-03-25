using System;


namespace DSP
{
    public class Correlation
    {
        public double Execute( double[] x1, double[] x2)
        {
            int length = Math.Min( x1.Length, x2.Length );
           
            double r = 0;
            for ( int i = 0; i < length; i++ )
            {
                r += x1[i] * x2[i];
            }
            r /= length;

            return r;
        }
    }
}
