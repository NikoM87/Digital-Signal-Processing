using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using DSP;
using DSP.Infrastructure;
using DSP.Statictics;


namespace Processing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Button1Click( object sender, EventArgs e )
        {
            using ( var loader = new SignalLoader( new FileStream( "3.ms", FileMode.Open ) ) )
            {

                List<Signal> listSignal = loader.Load();


                Signal signal1 = listSignal[1];
                double[] signal1A = signal1.ToArray;
                double[] shortSignal1 = new double[4096];
                for ( int i = 0; i < shortSignal1.Length; i++ )
                {
                    shortSignal1[i] = signal1A[i];
                }

                Signal signal2 = listSignal[2];

                double[] signal2A = signal2.ToArray;
                double[] shortSignal2 = new double[1024];
                for ( int i = 0; i < shortSignal2.Length; i++ )
                {
                    shortSignal2[i] = signal2A[i];
                }

                var points =  chart1.Series[0];
                points.Points.Clear();
                for ( int i = 0; i < shortSignal1.Length - shortSignal2.Length; i++ )
                {
                    points.Points.AddXY( i, Statictics.CrossCorrelation( i, shortSignal1, shortSignal2 ) );
                }

                label1.Text = "СКЗ 1: " + Statictics.Rms( signal1A ) + "  СКЗ 2: " + Statictics.Rms( signal2A );

            }
        }
    }
}
