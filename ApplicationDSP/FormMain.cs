using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using DSP;
using DSP.Infrastructure;
using DSP.Transformation;


namespace ApplicationDSP
{
    public partial class FormMain : Form
    {
        private readonly SignalController _signalController;

        private List<Signal> _signal1;
        private List<Signal> _signal2;
        private SignalLoader _signalLoader;


        public FormMain()
        {
            InitializeComponent();
            _signalController = new SignalController( chart1 );
            checkedListBox1.Items.Add( new RemoveConstant() );
        }


        private void ButtonLoadClick( object sender, EventArgs e )
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                string pathFile = openFileDialog1.FileName;
                textBoxLoad1.Text = pathFile;
                _signal1 = LoadSignalFromFile( pathFile );

                _signalController.UpdateSeries( _signal1[0], 0 );
            }
        }


        private List<Signal> LoadSignalFromFile( string pathFile )
        {
            Stream stream = new FileStream( pathFile, FileMode.Open );
            _signalLoader = new SignalLoader( stream );
            return _signalLoader.Load();
        }


        private void CheckedListBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            var transformations = new Transformations( checkedListBox1.CheckedItems );

            var tranformSignal1 = transformations.TranformationSignal( _signal1[0] );
            _signalController.UpdateSeries( tranformSignal1, 0 );

            var tranformSignal2 = transformations.TranformationSignal( _signal2[0] );
            _signalController.UpdateSeries( tranformSignal2, 1 );
        }


        private void Button1Click( object sender, EventArgs e )
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                string pathFile = openFileDialog1.FileName;
                textBoxLoad2.Text = pathFile;
                _signal2 = LoadSignalFromFile( pathFile );

                _signalController.UpdateSeries( _signal2[0], 1 );
            }
        }
    }
}