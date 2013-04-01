using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class SignalChankWriter : ChankWriter
    {
        public SignalChankWriter( BinaryWriter writer )
            : base( writer )
        {
            Id = SignalSaver.ChankSignal;
        }


        protected override void WriteData( object o )
        {
            Signal signal = (Signal) o;
            Writer.Write( signal.Df );
            Writer.Write( signal.Length );
            foreach ( double point in signal.Points )
            {
                Writer.Write( point );
            }
        }
    }
}