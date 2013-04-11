using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using DSP;
using DSP.Infrastructure;
using DSP.Transformation;


namespace ApplicationDSP.Controllers
{
    public class SignalMediator
    {
        private ChartSeriesColleague _chartSeriesColleague;
        private ComboBoxColleague _comboBoxColleague;
        private string _filePath;
        private List<Signal> _signals;
        private TextBoxCollegue _textBoxCollegue;
        private TransformationsColleague _transformationCollegue;
        private Transformations _transformations;


        private List<Signal> Signals
        {
            get { return _signals; }
            set
            {
                _signals = value;
                _comboBoxColleague.UpdateSignalCount( _signals );
            }
        }


        private string FilePath
        {
            set
            {
                _filePath = value;
                _textBoxCollegue.Update( _filePath );
            }
        }


        public void RegisterTransformation( Transformations transformations )
        {
            _transformations = transformations;
            _transformationCollegue.Update( _transformations );
        }


        internal void UpdateNumber( Colleague colleague )
        {
            if ( colleague == _comboBoxColleague )
            {
                _transformationCollegue.Update( _transformations );
            }
        }


        internal static SignalMediator Create( ComboBox comboBox, Series series, TextBox textBoxLoad1 )
        {
            var signalMediator = new SignalMediator();

            signalMediator._comboBoxColleague = new ComboBoxColleague( signalMediator, comboBox );
            signalMediator._chartSeriesColleague = new ChartSeriesColleague( signalMediator, series );
            signalMediator._transformationCollegue = new TransformationsColleague( signalMediator );
            signalMediator._textBoxCollegue = new TextBoxCollegue( signalMediator, textBoxLoad1 );

            return signalMediator;
        }


        public void UpdateTransformation( Transformations transformations )
        {
            _transformations = transformations;
            int selected = _comboBoxColleague.GetNumber();
            if ( selected >= 0 )
            {
                Signal tranformSignal1 = Signals[selected];
                if ( _transformations != null )
                {
                    tranformSignal1 = _transformations.TranformationSignal( tranformSignal1 );
                }
                _chartSeriesColleague.Notify( tranformSignal1 );
            }
        }


        public void LoadSignal()
        {
            string pathFile = AppDialogs.ShowOpenDialogForSignal();
            if ( pathFile != null )
            {
                FilePath = pathFile;
                Signals = SignalLoader.LoadFromFile( pathFile );
            }
        }
    }
}