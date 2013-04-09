using System.IO;


namespace DSP.Infrastructure.Chanks.Writer
{
    public static class ChankWriterFactory
    {
        public static ChankWriter GetWriter( TypesChank chank, BinaryWriter writer )
        {
            switch ( chank )
            {
                case TypesChank.Array:
                    return new ArrayChankWriter( writer );
                case TypesChank.Signal:
                    return new SignalChankWriter( writer );
            }
            return null;
        }
    }
}