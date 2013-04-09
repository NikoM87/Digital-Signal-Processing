namespace DSP.Infrastructure.Chanks
{
    public class SignalChank : Chank
    {
        public SignalChank()
        {
            Id = (ushort) TypesChank.Signal;
        }


        public SignalChank( Signal signal )
        {
            Data = signal;
        }


        protected override long GetSize()
        {
            return 0;
        }
    }
}