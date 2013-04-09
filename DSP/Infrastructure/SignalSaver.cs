using System;
using System.Collections.Generic;
using System.IO;

using DSP.Infrastructure.Chanks;
using DSP.Infrastructure.Chanks.Writer;


namespace DSP.Infrastructure
{
    public class SignalSaver
    {
        public const UInt32 SignatureFile = 0x01020304;

        public const UInt16 VersionFormatFile = 1;

        private readonly BinaryWriter _writer;


        public SignalSaver( Stream stream )
        {
            _writer = new BinaryWriter( stream );
        }


        public void Save( IEnumerable<Signal> signals )
        {
            SaveHeader();

            ArrayChank array = new ArrayChank( TypesChank.Signal );

            foreach ( Signal signal in signals )
            {
                array.Add( new SignalChank( signal ) );
            }

            ChankWriter arrayWriter = new ArrayChankWriter( _writer );
            arrayWriter.Write( array );

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