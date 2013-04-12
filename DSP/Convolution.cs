﻿namespace DSP
{
    public static class Convolution
    {
        public static double[] Execute( double[] x, double[] h )
        {
            int n = h.Length;

            var res = new double[n];

            for ( int i = 0; i < n; i++ )
            {
                for ( int j = 0; j < n; j++ )
                {
                    res[i] += h[j] * x[n + i - j];
                }
            }
            return res;
        }
    }
}