using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public abstract class ChankWriter : Chank
    {
        protected readonly BinaryWriter Writer;


        protected ChankWriter( BinaryWriter writer )
            : base( writer.BaseStream )
        {
            Writer = writer;
        }


        public void Write( object o )
        {
            WriteHeader();
            Position = ChankStream.Position;

            WriteData( o );

            Size = ChankStream.Position - Position;
            UpdateSize();
        }


        protected abstract void WriteData( object o );


        private void UpdateSize()
        {
            ChankStream.Seek( Position - sizeof ( ulong ), SeekOrigin.Begin );
            Writer.Write( Size );
            ChankStream.Seek( Size, SeekOrigin.Current );
        }


        private void WriteHeader()
        {
            Writer.Write( Id );
            Writer.Write( Size );
        }
    }
}