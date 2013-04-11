using System.Windows.Forms;


namespace ApplicationDSP
{
    public class AppDialogs
    {
        public static string ShowOpenDialogForSignal()
        {
            var openFileDialog = new OpenFileDialog();

            string pathFile = null;
            if ( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                pathFile = openFileDialog.FileName;
            }
            return pathFile;
        }
    }
}