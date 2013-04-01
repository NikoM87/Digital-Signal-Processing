using System.IO;


namespace DSP
{
    public class SignalChankWriter
    {
        private readonly BinaryWriter _writer;


        public SignalChankWriter( BinaryWriter writer  )
        {
            _writer = writer;
        }


        public void SaveChank( Signal signal )
        {
            _writer.Write( SignalSaver.ChankSignal );
          
            Stream signalChank = SaveSignal( signal );

            _writer.Write( signalChank.Length );
            signalChank.CopyTo( _writer.BaseStream );
        }


        private Stream SaveSignal( Signal signal )
        {
            var stream = new MemoryStream();

            var writer = new BinaryWriter( stream );

            writer.Write( signal.Df );
            writer.Write( signal.Length );
            foreach ( double point in signal.Points )
            {
                writer.Write( point );
            }

            stream.Position = 0;

            return stream;
        }
    }
}