using System;
using System.Collections.Generic;


namespace DSP.Infrastructure
{
    public class SignalRandomLoader : SignalLoader
    {
        public override List<Signal> Load()
        {
            Signal signal = new Signal();
            signal.Df = 0.1;

            Random random = new Random();

            for ( int i = 0; i < 128; i++ )
            {
                signal.AddPoint( random.Next( 0, 1024 ) );
            }

            return new List<Signal> {signal};
        }
    }
}