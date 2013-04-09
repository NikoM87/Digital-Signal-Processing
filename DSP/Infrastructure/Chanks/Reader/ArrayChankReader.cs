using System.IO;


namespace DSP.Infrastructure.Chanks.Reader
{
    public class ArrayChankReader : ChankReader
    {
        public ArrayChankReader( BinaryReader reader )
            : base( reader )
        {
        }


        public override object ReadData()
        {
            if ( Chank.Id != (ushort) TypesChank.Array )
            {
                throw new UnknownChankException( "Не известная структура данных" );
            }

            TypesChank typeItem = (TypesChank) Reader.ReadUInt16();
            int count = Reader.ReadInt32();

            ArrayChank list = new ArrayChank( typeItem );
            for ( int i = 0; i < count; i++ )
            {
                Chank chank = new Chank();

                ChankReader chankReader = ChankReaderFactory.GetChankReaderFactory( typeItem, Reader );
                chank.Id = chankReader.Chank.Id;
                chank.Size = chankReader.Chank.Size;
                chank.Data = chankReader.ReadData();

                list.Add( chank );
            }

            return list;
        }
    }
}