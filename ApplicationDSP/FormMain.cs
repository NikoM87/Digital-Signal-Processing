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
        private int _signal1Num;
        private List<Signal> _signal2;
        private int _signal2Num;
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

                UpdateSignalCount( _signal1, comboBox1.Items );

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
            int i1 = GetSelectedNumSignal( comboBox1 );
            int i2 = GetSelectedNumSignal( comboBox2 );

            var tranformSignal1 = transformations.TranformationSignal( _signal1[i1] );
            _signalController.UpdateSeries( tranformSignal1, 0 );

            var tranformSignal2 = transformations.TranformationSignal( _signal2[i2] );
            _signalController.UpdateSeries( tranformSignal2, 1 );
        }


        private void Button1Click( object sender, EventArgs e )
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                string pathFile = openFileDialog1.FileName;
                textBoxLoad2.Text = pathFile;
                _signal2 = LoadSignalFromFile( pathFile );

                UpdateSignalCount( _signal2, comboBox2.Items );

                _signalController.UpdateSeries( _signal2[0], 1 );
            }
        }


        private void UpdateSignalCount( List<Signal> signal2, ComboBox.ObjectCollection items )
        {
            items.Clear();
            for ( int i = 0; i < signal2.Count; i++ )
            {
                items.Add( i + 1 );
            }
        }


        private void ComboBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            var selected = GetSelectedNumSignal( (ComboBox) sender );

            _signalController.UpdateSeries( _signal1[selected], 0 );
        }


        private int GetSelectedNumSignal( ComboBox sender )
        {
            return (int) sender.SelectedItem - 1;
        }


        private void ComboBox2SelectedIndexChanged( object sender, EventArgs e )
        {
            int selected = GetSelectedNumSignal( (ComboBox) sender );

            _signalController.UpdateSeries( _signal2[selected], 1 );
        }
    }
}