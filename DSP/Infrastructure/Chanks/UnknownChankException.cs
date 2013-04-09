using System;


namespace DSP.Infrastructure.Chanks
{
    public class UnknownChankException : Exception
    {
        public UnknownChankException( string message )
            : base( message )
        {
        }
    }
}