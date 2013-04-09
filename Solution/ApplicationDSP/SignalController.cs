using System.Windows.Forms.DataVisualization.Charting;

using DSP;


namespace ApplicationDSP
{
    public class SignalController
    {
        private readonly Chart _chart1;


        public SignalController( Chart chart1 )
        {
            _chart1 = chart1;
        }


        public void UpdateSeries( Signal signal, int seriesNumber )
        {
            double[] pointsArray = signal.ToArray;
            double df = signal.Df;

            DataPointCollection pointCollection = _chart1.Series[seriesNumber].Points;
            pointCollection.SuspendUpdates();
            pointCollection.Clear();
            for ( int i = 0; i < pointsArray.Length; i += pointsArray.Length / 300 )
            {
                pointCollection.AddXY( i * df, pointsArray[i] );
            }
            pointCollection.ResumeUpdates();
        }
    }
}