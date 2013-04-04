using System.Collections.Generic;


namespace DSP.Infrastructure.Chanks
{
    public class ArrayChank : Chank
    {
        private readonly List<Chank> _list;


        public ArrayChank()
        {
            _list = new List<Chank>();

            Id = (ushort) TypesChank.Array;
        }


        public int Length
        {
            get { return _list.Count; }
        }


        public Chank this[ int index ]
        {
            get { return _list[index]; }
        }


        public void Add( Chank newChank )
        {
            _list.Add( newChank );
        }
    }
}