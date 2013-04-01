namespace DSP
{
    public class RemoveConstant : Transformation
    {
        public override Signal Execute( Signal signal )
        {
            double[] array = signal.ToArray;
            var mean = Statictics.Statictics.Mean( array );

            Signal meanSignal = new Signal();
            meanSignal.Df = signal.Df;

            for ( int i = 0; i < array.Length; i++ )
            {
                meanSignal.AddPoint( array[i] - mean );
            }

            return meanSignal;
        }


        public override string ToString()
        {
            return "Удаление постоянной составляющей";
        }
    }
}