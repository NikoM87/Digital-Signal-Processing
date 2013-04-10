﻿namespace DSP.Transformation
{
    public class RemoveConstant : ITransformation
    {
        public Signal Execute( Signal signal )
        {
            double[] array = signal.ToArray;
            double mean = Statictics.Statictics.Mean( array );

            var meanSignal = new Signal();
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