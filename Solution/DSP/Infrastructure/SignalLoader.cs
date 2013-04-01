using System.IO;

using DSP.Infrastructure.Chanks;


namespace DSP.Infrastructure
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

            ChankReader chankReader = new SignalChankReader( Reader );
            Signal signal = (Signal) chankReader.Read();

            return signal;
        }


        public void LoadHeader()
        {
            uint signature = Reader.ReadUInt32();
            if ( signature != SignalSaver.SignatureFile )
            {
                throw new SignatureException( "���� � ����������� ����������" );
            }
            Reader.ReadUInt16(); // ������

            ushort versionFile = Reader.ReadUInt16();
            if ( versionFile != SignalSaver.VersionFormatFile )
            {
                throw new FileVesionException( "����������� ������ �����" );
            }
        }
    }
}