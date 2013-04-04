using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class StreamedChank : Chank
    {
        public StreamedChank( Stream chankStream )
            : base( chankStream )
        {
            SizeHeaderChank = Position = chankStream.Position + SizeHeaderChank;
        }
    }
}