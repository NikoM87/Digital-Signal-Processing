using System.IO;


namespace DSP.Infrastructure.Chanks.Reader
{
    public static class ChankReaderFactory
    {
        public static ChankReader GetChankReaderFactory( TypesChank type, BinaryReader reader )
        {
            switch ( type )
            {
                case TypesChank.Signal:
                    return new SignalChankReader( reader );
                case TypesChank.Array:
                    return new ArrayChankReader( reader );
            }
            return null;
        }
    }
}