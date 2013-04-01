using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class Chank
    {
        protected readonly Stream ChankStream;
        public ushort Id;
        public long Position;
        public long Size;


        protected Chank( Stream chankStream )
        {
            ChankStream = chankStream;
        }
    }
}