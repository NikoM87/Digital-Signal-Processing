using System.IO;


namespace DSP
{
    public abstract class ChankReader
    {
        protected readonly BinaryReader Reader;
        public uint Id;
        public ulong Size;
        private long _position;


        public ChankReader( BinaryReader reader )
        {
            Reader = reader;
            LoadHeader();
        }


        public abstract object Read();


        private void LoadHeader()
        {
            Id = Reader.ReadUInt16();
            Size = Reader.ReadUInt64();
            _position = Reader.BaseStream.Position;
        }
    }
}