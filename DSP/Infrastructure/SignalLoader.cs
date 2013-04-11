using System;
using System.Collections.Generic;
using System.IO;

using DSP.Infrastructure.Chanks;
using DSP.Infrastructure.Chanks.Reader;


namespace DSP.Infrastructure
{
    public sealed class SignalLoader : IDisposable
    {
        private readonly BinaryReader _reader;


        public SignalLoader( Stream stream )
        {
            _reader = new BinaryReader( stream );
        }


        public void Dispose()
        {
            _reader.Dispose();
        }


        public List<Signal> Load()
        {
            LoadHeader();

            ChankReader chankReader = new ArrayChankReader( _reader );
            var arrayChank = (ArrayChank) chankReader.ReadData();

            var listSignal = new List<Signal>();
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


        public static List<Signal> LoadFromFile( string pathFile )
        {
            Stream stream = new FileStream( pathFile, FileMode.Open );
            var signalLoader = new SignalLoader( stream );
            List<Signal> signals = signalLoader.Load();
            stream.Close();

            return signals;
        }
    }
}