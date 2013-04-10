using System.IO;


namespace DSP.Infrastructure.Chanks.Writer
{
    public class SignalChankWriter : ChankWriter
    {
        public SignalChankWriter( BinaryWriter writer )
            : base( writer )
        {
            Id = (ushort) TypesChank.Signal;
        }


        protected override void WriteData( object o )
        {
            var signalChank = (SignalChank) o;
            var signal = (Signal) signalChank.Data;
            Writer.Write( signal.Df );
            Writer.Write( signal.Length );
            foreach ( double point in signal.Points )
            {
                Writer.Write( point );
            }
        }
    }
}