using System.IO;

using DSP.Infrastructure.Chanks;


namespace DSP.Infrastructure
{
    public class SignalLoader
    {
        private readonly BinaryReader _reader;


        public SignalLoader( Stream stream )
        {
            _reader = new BinaryReader( stream );
        }


        protected SignalLoader()
        {
        }


        public virtual Signal Load()
        {
            LoadHeader();

            ChankReader chankReader = new SignalChankReader( _reader );
            Signal signal = (Signal) chankReader.ReadData();

            return signal;
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