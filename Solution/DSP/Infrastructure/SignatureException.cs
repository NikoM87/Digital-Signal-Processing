using System;


namespace DSP.Infrastructure
{
    public class SignatureException : Exception
    {
        public SignatureException( string text )
            : base( text )
        {
        }
    }
}