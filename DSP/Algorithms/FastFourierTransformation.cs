using System;


namespace DSP.Algorithms
{
    public static class FastFourierTransformation
    {
        private static int Log2( int n )
        {
            int i = 0;
            while( n > 0 )
            {
                ++i;
                n >>= 1;
            }
            return i;
        }


        private static bool IsPowerOfTwo( int n )
        {
            return n > 1 && ( n & ( n - 1 ) ) == 0;
        }


        private static int ReverseBits( int n, int bitsCount )
        {
            int reversed = 0;
            for ( int i = 0; i < bitsCount; i++ )
            {
                int nextBit = n & 1;
                n >>= 1;

                reversed <<= 1;
                reversed |= nextBit;
            }
            return reversed;
        }


        private static int RoundToPowerTwo( int n )
        {
            if ( IsPowerOfTwo( n ) )
            {
                return n;
            }
            return 1 << Log2( n );
        }


        /// <summary>
        ///     Cooley-Tukey FFT אכדמנטעל.
        /// </summary>
        public static Complex[] Calculate( Complex[] x, Direction direction )
        {
            int length = RoundToPowerTwo( x.Length );
            int bitsInLength = Log2( length - 1 );

            var data = new Complex[length];
            for ( int i = 0; i < x.Length; i++ )
            {
                int j = ReverseBits( i, bitsInLength );
                data[j] = x[i];
            }

            // Cooley-Tukey 
            for ( int i = 0; i < bitsInLength; i++ )
            {
                int m = 1 << i;
                int n = m * 2;
                double alpha = -( 2 * Math.PI / n );

                for ( int k = 0; k < m; k++ )
                {
                    Complex oddPartMultiplier = new Complex( 0, alpha * k ).PoweredE();

                    for ( int j = k; j < length; j += n )
                    {
                        Complex evenPart = data[j];
                        Complex oddPart = oddPartMultiplier * data[j + m];
                        data[j] = evenPart + oddPart;
                        data[j + m] = evenPart - oddPart;
                    }
                }
            }

            if ( direction == Direction.Forward )
            {
                for ( int i = 0; i < length; i++ )
                {
                    data[i] /= length;
                }
            }

            return data;
        }
    }
}