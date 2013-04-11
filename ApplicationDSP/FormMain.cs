using System;
using System.Windows.Forms;

using ApplicationDSP.Controllers;

using DSP.Transformation;


namespace ApplicationDSP
{
    public partial class FormMain : Form
    {
        private readonly SignalMediator _signalMediator1;
        private readonly SignalMediator _signalMediator2;


        public FormMain()
        {
            InitializeComponent();
            checkedListBox1.Items.Add( new RemoveConstant() );

            _signalMediator1 = SignalMediator.Create( comboBox1, chart1.Series[0], textBoxLoad1 );
            _signalMediator2 = SignalMediator.Create( comboBox2, chart1.Series[1], textBoxLoad2 );
        }


        private void ButtonLoadClick( object sender, EventArgs e )
        {
            _signalMediator1.LoadSignal();
        }


        private void Button1Click( object sender, EventArgs e )
        {
            _signalMediator2.LoadSignal();
        }


        private void CheckedListBox1SelectedIndexChanged( object sender, EventArgs e )
        {
            var transformations = new Transformations( checkedListBox1.CheckedItems );
            _signalMediator1.RegisterTransformation( transformations );
            _signalMediator2.RegisterTransformation( transformations );
        }
    }
}