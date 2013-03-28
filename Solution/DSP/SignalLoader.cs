using System.IO;


namespace DSP
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
            LoadSignalChankHeader();

            Signal signal = LoadSignal( );

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


        public Signal LoadSignal()
        {
            

            Signal signal = new Signal();
            signal.Df = _reader.ReadDouble();

            int countPoints = _reader.ReadInt32();
            signal.Points.Capacity = countPoints;

            for ( int i = 0; i < countPoints; i++ )
            {
                signal.AddPoint( _reader.ReadDouble() );
            }

            return signal;
        }


        public void LoadSignalChankHeader()
        {
            ushort chankCode = _reader.ReadUInt16();
            if ( chankCode != SignalSaver.ChankSignal )
            {
                throw new UnknownChankException( "Не известная структура данных" );
            }

            _reader.ReadUInt64(); // размер данных
        }
    }
}