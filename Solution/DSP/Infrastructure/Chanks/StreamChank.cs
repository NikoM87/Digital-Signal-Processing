using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class StreamChank : Chank
    {
        private const long SizeHeaderChank = 10;
        public readonly Stream ChankStream;
        public long Position;


        public StreamChank( Stream chankStream )
        {
            ChankStream = chankStream;

            Position = ChankStream.Position + SizeHeaderChank;
        }
    }
}