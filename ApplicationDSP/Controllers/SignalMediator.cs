using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using DSP;
using DSP.Transformation;


namespace ApplicationDSP.Controllers
{
    public class SignalMediator : Mediator
    {
        public List<Signal> List { get; set; }


        public ComboBoxColleague ComboBoxColleague { get; set; }

        public ChartSeriesColleague ChartSeriesColleague { get; set; }

        private Transformations _transformations;


        public override void UpdateNumber( int selected, Colleague colleague )
        {
            if ( colleague == ComboBoxColleague )
            {
                TransformationCollegue.Update( _transformations );
            }
        }


        public static SignalMediator CreateSignalMediator( ComboBox comboBox, Series series )
        {
            var signalController = new SignalController();
            var signalMediator = new SignalMediator();
            ComboBoxColleague colleagueComboBox = new ComboBoxColleague( signalMediator, comboBox );
            ChartSeriesColleague colleagueChartSeries = new ChartSeriesColleague( signalMediator, series,
                signalController );
            TransformationsColluegue collueguetraTransformations = new TransformationsColluegue( signalMediator );
            signalMediator.ComboBoxColleague = colleagueComboBox;
            signalMediator.ChartSeriesColleague = colleagueChartSeries;
            signalMediator.TransformationCollegue = collueguetraTransformations;

            return signalMediator;
        }


        public TransformationsColluegue TransformationCollegue { get; set; }


        public override void UpdateTransformation( Transformations transformations )
        {
            _transformations = transformations;
            int selected = ComboBoxColleague.GetNumber();
            if ( selected >= 0 )
            {
                Signal tranformSignal1 = List[selected];
                if ( _transformations != null )
                {
                    tranformSignal1 = _transformations.TranformationSignal( tranformSignal1 );
                }
                ChartSeriesColleague.Notify( tranformSignal1 );
            }
        }
    }
}