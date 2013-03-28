using System;


namespace DSP
{
    public class SignatureException : Exception
    {
        public SignatureException( string text )
            : base( text )
        {
            
        }
    }
}