using System.Collections.Generic;


namespace DSP
{
    public class Signal
    {
        private readonly List<double> _points;


        public Signal()
        {
            Df = 0;
            _points = new List<double>();
        }


        public double Df { get; set; }

        public List<double> Points
        {
            get { return _points; }
        }

        public double[] ToArray
        {
            get { return _points.ToArray(); }
        }

        public int Length
        {
            get { return _points.Count; }
        }


        public void AddPoint( double value )
        {
            _points.Add( value );
        }


        public Signal Copy()
        {
            var signal = new Signal();
            signal.Df = Df;
            signal._points.AddRange( _points );

            return signal;
        }
    }
}