using System.Collections.Generic;
using System.IO;


namespace DSP.Infrastructure.Chanks
{
    public class ChankArray : Chank
    {
        public const ushort ChankArrayType = 2;
        private readonly List<Chank> _list;


        public ChankArray( Stream chankStream )
            : base( chankStream )
        {
            _list = new List<Chank>();

            Id = ChankArrayType;
        }


        public int Length
        {
            get { return _list.Count; }
        }



        public void Add( Chank newChank )
        {
            _list.Add( newChank );
        }
    }
}