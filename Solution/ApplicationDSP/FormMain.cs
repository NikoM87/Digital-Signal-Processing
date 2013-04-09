using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using DSP;
using DSP.Infrastructure;


namespace ApplicationDSP
{
    public partial class FormMain : Form
    {
        private readonly SignalController _signalController;

        private Signal _signal1;
        private Signal _signal2;
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

                _signalController.UpdateSeries( _signal1, 0 );
            }
        }


        private Signal LoadSignalFromFile( string pathFile )
        {
            Stream stream = new FileStream( pathFile, FileMode.Open );
            _signalLoader = new SignalLoader( stream );
            return _signalLoader.Load();
        }


        private void CheckedListBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            var transformations = AdapterTransformations( checkedListBox1.CheckedItems );

            var tranformSignal1 = TranformationSignal( _signal1, transformations );
            _signalController.UpdateSeries( tranformSignal1, 0 );

            var tranformSignal2 = TranformationSignal( _signal2, transformations );
            _signalController.UpdateSeries( tranformSignal2, 1 );
        }


        private static IList<Transformation> AdapterTransformations( IEnumerable collectionTransformation )
        {
            var transformations = new List<Transformation>();
            foreach ( Transformation transformation in collectionTransformation )
            {
                transformations.Add( transformation );
            }
            return transformations;
        }


        private static Signal TranformationSignal( Signal signal, IEnumerable<Transformation> transformations )
        {
            Signal tranformSignal1 = signal.Copy();
            foreach ( var item in transformations )
            {
                tranformSignal1 = item.Execute( tranformSignal1 );
            }
            return tranformSignal1;
        }


        private void Button1Click( object sender, EventArgs e )
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                string pathFile = openFileDialog1.FileName;
                textBoxLoad2.Text = pathFile;
                _signal2 = LoadSignalFromFile( pathFile );

                _signalController.UpdateSeries( _signal2, 1 );
            }
        }
    }
}