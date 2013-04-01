using System;
using System.IO;

using DSP.Infrastructure.Chanks;


namespace DSP.Infrastructure
{
    public class SignalSaver
    {
        public const UInt32 SignatureFile = 0x01020304;

        public const UInt16 VersionFormatFile = 1;

        public const UInt16 ChankSignal = 0x0001;
        private readonly BinaryWriter _writer;

        public SignalSaver( Stream stream )
        {
            _writer = new BinaryWriter( stream );
 }


        public void Save( Signal signal )
        {
            SaveHeader();

           
            SignalChankWriter chankWriter = new SignalChankWriter( _writer );
            chankWriter.SaveChank( signal );

            _writer.Flush();
        }


        private void SaveHeader()
        {
            _writer.Write( SignatureFile );
            _writer.Write( (UInt16) 0000 ); // резерв
            _writer.Write( VersionFormatFile );
        }
    }
}