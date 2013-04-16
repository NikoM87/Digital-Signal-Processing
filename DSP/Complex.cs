using System;


namespace DSP
{
    public struct Complex
    {
        public readonly double Im;
        public readonly double Re;


        public Complex( double re )
        {
            Re = re;
            Im = 0;
        }


        public Complex( double re, double im )
        {
            Re = re;
            Im = im;
        }


        public static Complex operator *( Complex a, Complex b )
        {
            return new Complex( a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im );
        }


        public static Complex operator /( Complex a, double b )
        {
            return new Complex( a.Re / b, b * a.Im / Math.Pow( b, 2 ) );
        }


        public static Complex operator +( Complex a, Complex n2 )
        {
            return new Complex( a.Re + n2.Re, a.Im + n2.Im );
        }


        public static Complex operator -( Complex a, Complex b )
        {
            return new Complex( a.Re - b.Re, a.Im - b.Im );
        }


        public static Complex operator -( Complex a )
        {
            return new Complex( -a.Re, -a.Im );
        }


        public static implicit operator Complex( double a )
        {
            return new Complex( a, 0 );
        }


        public Complex PoweredE()
        {
            double e = Math.Exp( Re );
            return new Complex( e * Math.Cos( Im ), e * Math.Sin( Im ) );
        }

        public double Abs()
        {
            return Math.Sqrt( Re*Re + Im*Im );
        }


        public override string ToString()
        {
            return Re + "+i" + Im;
        }
    }
}