using System;


namespace DSP.Infrastructure
{
    [Serializable]
    public class SignatureException : Exception
    {
        public SignatureException( string text )
            : base( text )
        {
        }
    }
}