using System;
using System.IO;


namespace DSP
{
    public class SignalSaver
    {
        public const UInt32 SignatureFile = 0x01020304;

        public const UInt16 VersionFormatFile = 1;

        public const UInt16 ChankSignal = 0x0001;
        private BinaryWriter _writer;


        public void Save( Stream stream, Signal signal )
        {
            _writer = new BinaryWriter( stream );

            SaveHeader();

            Stream signalChank = SaveSignal( signal );
            SaveChank( signalChank );

            _writer.Flush();
        }


        private void SaveChank( Stream signalChank )
        {
            _writer.Write( ChankSignal );
            _writer.Write( signalChank.Length );
            signalChank.CopyTo( _writer.BaseStream );
        }


        private void SaveHeader()
        {
            _writer.Write( SignatureFile );
            _writer.Write( (UInt16) 0000 ); // резерв
            _writer.Write( VersionFormatFile );
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