using System;
using System.Linq;


namespace DSP.Statictics
{
    public static class Statictics
    {
        public static double Correlation( double[] x1, double[] x2 )
        {
            return Correlation( 0, x1, x2 );
        }


        public static double EdgeEffect( int j, int count, double r12 )
        {
            return j * r12 / count;
        }


        public static double Correlation( int delay, double[] x1, double[] x2 )
        {
            int length = Math.Min( x1.Length, x2.Length );

            double r = 0;
            for ( int i = 0; i < length; i++ )
            {
                r += x1[i + delay] * x2[i];
            }
            r /= length;

            return r;
        }


        public static double CrossCorrelation( int delay, double[] x1, double[] x2 )
        {
            int length = Math.Min( x1.Length, x2.Length );

            double r = Correlation( delay, x1, x2 );

            double x12 = 0;
            for ( int i = delay; i < length + delay; i++ )
            {
                x12 += Math.Pow( x1[i], 2 );
            }

            double x22 = 0;
            for ( int i = 0; i < length; i ++ )
            {
                x22 += Math.Pow( x2[i], 2 );
            }

            double k = 1.0 / ( length ) * Math.Sqrt( x12 * x22 );

            return r / k;
        }


        public static double Mean( double[] array )
        {
            double mean = array.Sum();
            mean /= array.Length;

            return mean;
        }


        public static double Rms( double[] x1 )
        {
            return x1.Sum( x => x * x ) / x1.Length;
        }
    }
}