using System;
using System.IO;


namespace DSP.Infrastructure.Chanks.Writer
{
    public class ArrayChankWriter : ChankWriter
    {
        public ArrayChankWriter( BinaryWriter writer )
            : base( writer )
        {
            Id = (ushort) TypesChank.Array;
        }


        protected override void WriteData( object o )
        {
            ArrayChank listChank = (ArrayChank) o;

            Writer.Write( (UInt16) listChank.Type );
            Writer.Write( listChank.Length );

            foreach ( Chank chank in listChank )
            {
                ChankWriter subWriter = ChankWriterFactory.GetWriter( listChank.Type, Writer );
                subWriter.Write( chank );
            }
        }
    }
}