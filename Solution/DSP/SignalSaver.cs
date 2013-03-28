using System;
using System.IO;


namespace DSP
{
    public class SignalSaver
    {
        public const UInt32 SignatureFile = 0x01020304;

        public const UInt16 VersionFormatFile = 1;

        public const UInt16 ChankSignal = 0x0001;


        public void Save( Stream stream, Signal signal )
        {
            var writer = new BinaryWriter( stream );

            writer.Write( SignatureFile );
            writer.Write( (UInt16) 0000 ); // резерв
            writer.Write( VersionFormatFile );

            Stream signalChank = SaveSignal( signal );
            writer.Write( ChankSignal );
            writer.Write( signalChank.Length );
            signalChank.CopyTo( writer.BaseStream );

            writer.Flush();
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