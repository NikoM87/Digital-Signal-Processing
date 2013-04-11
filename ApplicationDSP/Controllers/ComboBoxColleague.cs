using System;
using System.Collections;
using System.Windows.Forms;


namespace ApplicationDSP.Controllers
{
    public class ComboBoxColleague : Colleague
    {
        private readonly ComboBox _comboBox;


        public ComboBoxColleague( SignalMediator mediator, ComboBox comboBox )
            : base( mediator )
        {
            _comboBox = comboBox;
            _comboBox.SelectedIndexChanged += Checked;
        }


        public void Checked( object sender, EventArgs e )
        {
            Mediator.UpdateNumber( this );
        }


        public int GetNumber()
        {
            if ( _comboBox.SelectedItem == null )
            {
                return -1;
            }
            return (int) _comboBox.SelectedItem - 1;
        }


        public void UpdateSignalCount( ICollection signal2 )
        {
            ComboBox.ObjectCollection items = _comboBox.Items;

            items.Clear();
            for ( int i = 0; i < signal2.Count; i++ )
            {
                items.Add( i + 1 );
            }

            _comboBox.SelectedIndex = 0;
        }
    }
}