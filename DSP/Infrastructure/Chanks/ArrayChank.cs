using System.Collections;
using System.Collections.Generic;


namespace DSP.Infrastructure.Chanks
{
    public class ArrayChank : Chank, IEnumerable<Chank>
    {
        private readonly List<Chank> _list;


        public ArrayChank( TypesChank type )
        {
            _list = new List<Chank>();

            Id = (ushort) TypesChank.Array;
            Type = type;
        }


        public TypesChank Type { get; set; }

        public int Length
        {
            get { return _list.Count; }
        }


        public Chank this[ int index ]
        {
            get { return _list[index]; }
        }


        public IEnumerator<Chank> GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add( Chank newChank )
        {
            _list.Add( newChank );
        }
    }
}