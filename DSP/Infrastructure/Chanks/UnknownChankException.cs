using System;


namespace DSP.Infrastructure.Chanks
{
    [Serializable]
    public class UnknownChankException : Exception
    {
        public UnknownChankException( string message )
            : base( message )
        {
        }
    }
}