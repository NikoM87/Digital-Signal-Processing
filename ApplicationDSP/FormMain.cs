using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ApplicationDSP.Controllers;

using DSP;
using DSP.Infrastructure;
using DSP.Transformation;


namespace ApplicationDSP
{
    public partial class FormMain : Form
    {
        private readonly SignalMediator _signalMediator1;
        private readonly SignalMediator _signalMediator2;
        private List<Signal> _signal1;
        private List<Signal> _signal2;


        public FormMain()
        {
            InitializeComponent();
            checkedListBox1.Items.Add( new RemoveConstant() );

            _signalMediator1 = SignalMediator.CreateSignalMediator( comboBox1, chart1.Series[0] );
            _signalMediator2 = SignalMediator.CreateSignalMediator( comboBox2, chart1.Series[1] );
        }


        private void ButtonLoadClick( object sender, EventArgs e )
        {
            string pathFile = ShowOpenDialogForSignal();

            if ( pathFile != null )
            {
                textBoxLoad1.Text = pathFile;
                _signal1 = SignalLoader.LoadFromFile( pathFile );

                _signalMediator1.List = _signal1;
                SignalController.UpdateSignalCount( _signal1, comboBox1.Items );
                comboBox1.SelectedIndex = 0;
                _signalMediator1.UpdateNumber( 0, null );
            }
        }


        private string ShowOpenDialogForSignal()
        {
            string pathFile = null;
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                pathFile = openFileDialog1.FileName;
            }
            return pathFile;
        }


        private void CheckedListBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            var transformations = new Transformations( checkedListBox1.CheckedItems );

            _signalMediator1.TransformationCollegue.Update( transformations );
            _signalMediator2.TransformationCollegue.Update( transformations );
        }


        private void Button1Click( object sender, EventArgs e )
        {
            string pathFile = ShowOpenDialogForSignal();

            if ( pathFile != null )
            {
                textBoxLoad2.Text = pathFile;
                _signal2 = SignalLoader.LoadFromFile( pathFile );

                _signalMediator2.List = _signal2;
                SignalController.UpdateSignalCount( _signal2, comboBox2.Items );
                comboBox2.SelectedIndex = 0;
                _signalMediator2.UpdateNumber( 0, null );
            }
        }


        private void ComboBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            int selected = _signalMediator1.ComboBoxColleague.GetNumber();
            _signalMediator1.ComboBoxColleague.Checked( selected );
        }


        private void ComboBox2SelectedIndexChanged( object sender, EventArgs e )
        {
            int selected = _signalMediator2.ComboBoxColleague.GetNumber();
            _signalMediator2.ComboBoxColleague.Checked( selected );
        }
    }
}