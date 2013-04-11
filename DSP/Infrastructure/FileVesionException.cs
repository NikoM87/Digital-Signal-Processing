using System;


namespace DSP.Infrastructure
{
    [Serializable]
    public class FileVesionException : Exception
    {
        public FileVesionException( string message )
            : base( message )
        {
        }
    }
}