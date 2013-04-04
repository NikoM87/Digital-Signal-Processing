using System.IO;


namespace DSP.Infrastructure.Chanks.Reader
{
    public abstract class ChankReader
    {
        protected readonly BinaryReader Reader;


        protected ChankReader( BinaryReader reader )
        {
            Chank = new Chank();

            Reader = reader;
            LoadHeader();
        }


        public Chank Chank { get; private set; }


        public abstract object ReadData();


        private void LoadHeader()
        {
            Chank.Id = Reader.ReadUInt16();
            Chank.Size = Reader.ReadInt64();
            // Chank.Position = Chank.ChankStream.Position;
        }
    }
}