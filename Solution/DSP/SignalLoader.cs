using System.IO;


namespace DSP
{
    public abstract class SignalLoader
    {
        public abstract Signal Load( Stream stream );
    }
}