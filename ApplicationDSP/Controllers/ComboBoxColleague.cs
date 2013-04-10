using System.Windows.Forms;


namespace ApplicationDSP.Controllers
{
    public class ComboBoxColleague : Colleague
    {
        private readonly ComboBox _comboBox1;


        public ComboBoxColleague( Mediator mediator, ComboBox comboBox1 )
            : base( mediator )
        {
            _comboBox1 = comboBox1;
        }


        public void Checked( int selected )
        {
            Mediator.UpdateNumber( selected, this );
        }


        public int GetNumber()
        {
            if ( _comboBox1.SelectedItem == null )
            {
                return -1;
            }
            return (int) _comboBox1.SelectedItem - 1;
        }
    }
}