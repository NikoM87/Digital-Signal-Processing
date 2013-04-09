using System.Collections.Generic;
using System.IO;


namespace DSP.Infrastructure.Chanks.Reader
{
    public class ArrayChankReader : ChankReader
    {
        public ArrayChankReader( BinaryReader reader )
            : base( reader )
        {
            Chank.Id = (ushort) TypesChank.Array;
        }


        public override object ReadData()
        {
            if ( Chank.Id != (ushort) TypesChank.Array )
            {
                throw new UnknownChankException( "Не известная структура данных" );
            }

            TypesChank typeItem = (TypesChank) Reader.ReadUInt16();
            int count = Reader.ReadInt32();

            List<Chank> list = new List<Chank>( count );
            for ( int i = 0; i < count; i++ )
            {
                Chank chank = new Chank();

                ChankReader signal = ChankReaderFactory.GetChankReaderFactory( typeItem, Reader );
                chank.Id = signal.Chank.Id;
                chank.Size = signal.Chank.Size;
                chank.Data = signal.ReadData();

                list.Add( chank );
            }

            return list;
        }
    }
}