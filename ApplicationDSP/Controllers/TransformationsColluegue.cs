using DSP.Transformation;


namespace ApplicationDSP.Controllers
{
    public class TransformationsColluegue : Colleague
    {
        public TransformationsColluegue( Mediator mediator )
            : base( mediator )
        {
        }


        public void Update( Transformations transformations )
        {
            Mediator.UpdateTransformation( transformations );
        }
    }
}