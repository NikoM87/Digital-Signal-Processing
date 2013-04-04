namespace DSP.Infrastructure.Chanks
{
    public class Chank
    {
        private long _size;

        public object Data { get; set; }


        public long Size
        {
            get { return GetSize(); }
            set { _size = value; }
        }


        public ushort Id { get; set; }


        protected virtual long GetSize()
        {
            return _size;
        }
    }
}