using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using DSP;


namespace ApplicationDSP.Controllers
{
    public class SignalController
    {

        public void UpdateSeries( Signal signal, Series series )
        {
            double[] pointsArray = signal.ToArray;
            double df = signal.Df;

            DataPointCollection pointCollection = series.Points;
            pointCollection.SuspendUpdates();
            pointCollection.Clear();
            for ( int i = 0; i < pointsArray.Length; i += pointsArray.Length / 300 )
            {
                pointCollection.AddXY( i * df, pointsArray[i] );
            }
            pointCollection.ResumeUpdates();
        }


        public int GetSelectedNumSignal( ComboBox sender )
        {
            return (int) sender.SelectedItem - 1;
        }


        public static void UpdateSignalCount( ICollection signal2, ComboBox.ObjectCollection items )
        {
            items.Clear();
            for ( int i = 0; i < signal2.Count; i++ )
            {
                items.Add( i + 1 );
            }
        }
    }
}