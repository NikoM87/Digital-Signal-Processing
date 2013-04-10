using System.Collections.Generic;
using System.IO;

using DSP.Infrastructure.Chanks;
using DSP.Infrastructure.Chanks.Reader;


namespace DSP.Infrastructure
{
    public class SignalLoader
    {
        private readonly BinaryReader _reader;


        public SignalLoader( Stream stream )
        {
            _reader = new BinaryReader( stream );
        }


        public virtual List<Signal> Load()
        {
            LoadHeader();

            ChankReader chankReader = new ArrayChankReader( _reader );
            ArrayChank arrayChank = (ArrayChank) chankReader.ReadData();

            List<Signal> listSignal = new List<Signal>();
            foreach ( Chank chank in arrayChank )
            {
                listSignal.Add( (Signal) chank.Data );
            }

            return listSignal;
        }


        public void LoadHeader()
        {
            uint signature = _reader.ReadUInt32();
            if ( signature != SignalSaver.SignatureFile )
            {
                throw new SignatureException( "Файл с неизвестной сигнатурой" );
            }
            _reader.ReadUInt16(); // резерв

            ushort versionFile = _reader.ReadUInt16();
            if ( versionFile != SignalSaver.VersionFormatFile )
            {
                throw new FileVesionException( "Неизвестная версия файла" );
            }
        }
    }
}