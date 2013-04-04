using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class ChankSignal : Chank
    {
        public ChankSignal( Stream chankStream )
            : base( chankStream )
        {
        }


        protected override long GetSize()
        {
            return 0;
        }
    }
}