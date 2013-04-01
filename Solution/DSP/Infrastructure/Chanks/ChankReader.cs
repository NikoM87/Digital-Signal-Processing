using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public abstract class ChankReader : Chank
    {
        protected readonly BinaryReader Reader;


        protected ChankReader( BinaryReader reader )
            : base( reader.BaseStream )
        {
            Reader = reader;
            LoadHeader();
        }


        public abstract object ReadData();


        private void LoadHeader()
        {
            Id = Reader.ReadUInt16();
            Size = Reader.ReadInt64();
            Position = ChankStream.Position;
        }
    }
}