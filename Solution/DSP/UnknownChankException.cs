using System;


namespace DSP
{
    public class UnknownChankException : Exception
    {
        public UnknownChankException( string message )
            : base( message )
        {
        }
    }
}