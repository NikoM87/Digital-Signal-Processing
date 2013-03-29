using System.IO;


namespace DSP
{
    public class SignalLoader
    {
        protected readonly BinaryReader Reader;


        public SignalLoader( Stream stream )
        {
            Reader = new BinaryReader( stream );
        }


        protected SignalLoader()
        {
        }


        public virtual Signal Load()
        {
            LoadHeader();

            ChankReader chankReader = new SignalChank( Reader );
            Signal signal = (Signal) chankReader.Read();

            return signal;
        }


        public void LoadHeader()
        {
            uint signature = Reader.ReadUInt32();
            if ( signature != SignalSaver.SignatureFile )
            {
                throw new SignatureException( "Файл с неизвестной сигнатурой" );
            }
            Reader.ReadUInt16(); // резерв

            ushort versionFile = Reader.ReadUInt16();
            if ( versionFile != SignalSaver.VersionFormatFile )
            {
                throw new FileVesionException( "Неизвестная версия файла" );
            }
        }
    }
}