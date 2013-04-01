using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class SignalChankReader : ChankReader
    {
        public SignalChankReader( BinaryReader reader )
            : base( reader )
        {
        }


        public override object Read()
        {
            if ( Id != SignalSaver.ChankSignal )
            {
                throw new UnknownChankException( "Не известная структура данных" );
            }

            Signal signal = new Signal();
            signal.Df = Reader.ReadDouble();

            int countPoints = Reader.ReadInt32();
            signal.Points.Capacity = countPoints;

            for ( int i = 0; i < countPoints; i++ )
            {
                signal.AddPoint( Reader.ReadDouble() );
            }

            return signal;
        }
    }
}