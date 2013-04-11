using System.Windows.Forms;


namespace ApplicationDSP.Controllers
{
    public class TextBoxCollegue : Colleague
    {
        private readonly TextBox _textBoxLoad1;


        public TextBoxCollegue( SignalMediator signalMediator, TextBox textBoxLoad1 )
            : base( signalMediator )
        {
            _textBoxLoad1 = textBoxLoad1;
        }


        public void Update( string filePath )
        {
            _textBoxLoad1.Text = filePath;
        }
    }
}