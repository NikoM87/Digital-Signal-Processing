using System;
using System.Linq;


namespace DSP.Statictics
{
    public class Statictics
    {
        public static double Correlation( double[] x1, double[] x2)
        {
            return Correlation( 0, x1, x2 );
        }


        public static double EdgeEffect( int j, int count, double r12)
        {
            return j * r12 / count;
        }

        public static double Correlation( int delay, double[] x1, double[] x2 )
        {
            int length = Math.Min( x1.Length, x2.Length - delay );

            double r = 0;
            for ( int i = 0; i < length ; i++ )
            {
                r += x1[i] * x2[i + delay];
            }
            r /= length + delay;

            return r ;
        }

        public static double CrossCorrelation( int delay, double[] x1, double[] x2 )
        {
            int length = Math.Min( x1.Length, x2.Length ) - delay;

            double r = Correlation( delay, x1, x2 );

            double x12 = x1.Sum( x => x * x );
            double x22 = x2.Sum( x => x * x );

            double k = 1.0 / ( length + delay ) * Math.Sqrt( x12 * x22 );

            return r / k;
        }


        public static double Mean( double[] array )
        {
            double mean = array.Sum();
            mean /= array.Length;

            return mean;
        }
    }
}
