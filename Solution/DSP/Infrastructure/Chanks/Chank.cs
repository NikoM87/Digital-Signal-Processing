using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class Chank
    {
        protected static long SizeHeaderChank = 10;
        protected readonly Stream ChankStream;
        public long Position;
        private long _size;


        protected Chank( Stream chankStream )
        {
            ChankStream = chankStream;
        }


        public object Data { get; protected set; }


        public long Size
        {
            get { return GetSize(); }
            protected set { _size = value; }
        }


        public ushort Id { get; protected set; }


        protected virtual long GetSize()
        {
            return _size;
        }
    }
}