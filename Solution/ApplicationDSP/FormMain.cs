using System;
using System.IO;
using System.Windows.Forms;

using DSP;
using DSP.Infrastructure;


namespace ApplicationDSP
{
    public partial class FormMain : Form
    {
        private readonly SignalController _signalController;

        private Signal _signal;
        private SignalLoader _signalLoader;


        public FormMain()
        {
            InitializeComponent();
            _signalController = new SignalController();
            checkedListBox1.Items.Add( new RemoveConstant() );
        }


        private void ButtonLoadClick( object sender, EventArgs e )
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                string pathFile = openFileDialog1.FileName;
                Stream stream = new FileStream( pathFile, FileMode.Open );
                _signalLoader = new SignalLoader( stream );
                _signal = _signalLoader.Load();

                _signalController.UpdateSeries( _signal, chart1.Series[0].Points );
            }
        }


        private void CheckedListBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            Signal tranformSignal = _signal.Copy();
            foreach ( var item in checkedListBox1.CheckedItems )
            {
                tranformSignal = ( (Transformation) item ).Execute( tranformSignal );
            }

            _signalController.UpdateSeries( tranformSignal, chart1.Series[0].Points );
        }
    }
}