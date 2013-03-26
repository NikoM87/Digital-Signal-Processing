﻿using System.Windows.Forms.DataVisualization.Charting;

using DSP;


namespace ApplicationDSP
{
    public class SignalController
    {
        public void UpdateSeries( Signal signal, DataPointCollection pointCollection )
        {
            double[] pointsArray = signal.ToArray;
            double df = signal.Df;

            pointCollection.Clear();
            for ( int i = 0; i < pointsArray.Length; i ++ )
            {
                pointCollection.AddXY( i * df, pointsArray[i] );
            }
        }
    }
}