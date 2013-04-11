using System.Windows.Forms.DataVisualization.Charting;

using DSP;


namespace ApplicationDSP.Controllers
{
    public class ChartSeriesColleague : Colleague
    {
        private readonly Series _series;


        public ChartSeriesColleague( SignalMediator mediator, Series series )
            : base( mediator )
        {
            _series = series;
        }


        public void Notify( Signal signal )
        {
            UpdateSeries( signal );
        }


        private void UpdateSeries( Signal signal )
        {
            double[] pointsArray = signal.ToArray;
            double df = signal.Df;

            DataPointCollection pointCollection = _series.Points;
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