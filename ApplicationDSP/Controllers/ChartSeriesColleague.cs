using System.Windows.Forms.DataVisualization.Charting;

using DSP;


namespace ApplicationDSP.Controllers
{
    public class ChartSeriesColleague : Colleague
    {
        private readonly SignalController _controller;
        private readonly Series _series;


        public ChartSeriesColleague( Mediator mediator, Series series, SignalController controller )
            : base( mediator )
        {
            _series = series;
            _controller = controller;
        }


        public void Notify( Signal signal )
        {
            _controller.UpdateSeries( signal, _series );
        }
    }
}