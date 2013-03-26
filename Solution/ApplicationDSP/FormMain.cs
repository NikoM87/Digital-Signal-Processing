using System;
using System.Windows.Forms;

using DSP;


namespace ApplicationDSP
{
    public partial class FormMain : Form
    {
        private readonly SignalController _signalController;

        private Signal signal;
        public FormMain()
        {
            InitializeComponent();
            _signalController = new SignalController();
              checkedListBox1.Items.Add( new RemoveConstant() );
     }


        private readonly SignalLoader _signalRandomLoader = new SignalRandomLoader();


        private void Button1Click( object sender, EventArgs e )
        {
            signal = _signalRandomLoader.Load( null );

            _signalController.UpdateSeries( signal, chart1.Series[0].Points );            

           
        }

        private void checkedListBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            Signal tranformSignal = signal.Copy();
            foreach ( var item in checkedListBox1.CheckedItems )
            {
                tranformSignal = ( (Transformation)item ).Execute( tranformSignal );   
            }

            _signalController.UpdateSeries( tranformSignal, chart1.Series[0].Points );
        }
    }
}
