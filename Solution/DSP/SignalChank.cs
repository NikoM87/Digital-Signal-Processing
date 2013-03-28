using System.IO;


namespace DSP
{
    public class SignalChank : ChankReader
    {
        public Signal Signal;


        public SignalChank( BinaryReader reader )
            : base( reader )
        {
           
        }


        public override void Read()
        {
            base.Read();

            if ( Id != SignalSaver.ChankSignal )
            {
                throw new UnknownChankException( "Не известная структура данных" );
            }

            Signal = new Signal();
            Signal.Df = Reader.ReadDouble();

            int countPoints = Reader.ReadInt32();
            Signal.Points.Capacity = countPoints;

            for ( int i = 0; i < countPoints; i++ )
            {
                Signal.AddPoint( Reader.ReadDouble() );
            }
        }
    }
}