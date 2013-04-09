using System.Collections;
using System.Collections.Generic;


namespace DSP
{
    public class Transformations : List<ITransformation>
    {
        public Transformations( IEnumerable enumerable )
        {
            AddTransformations( enumerable );
        }


        public Transformations()
        {
        }


        private void AddTransformations( IEnumerable collectionTransformation )
        {
            foreach ( ITransformation transformation in collectionTransformation )
            {
                Add( transformation );
            }
        }


        public Signal TranformationSignal( Signal signal )
        {
            Signal tranformSignal1 = signal.Copy();
            foreach ( var item in this )
            {
                tranformSignal1 = item.Execute( tranformSignal1 );
            }
            return tranformSignal1;
        }
    }
}