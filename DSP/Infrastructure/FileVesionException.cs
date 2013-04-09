using System;


namespace DSP.Infrastructure
{
    public class FileVesionException : Exception
    {
        public FileVesionException( string message )
            : base( message )
        {
        }
    }
}