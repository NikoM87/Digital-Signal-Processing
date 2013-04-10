using DSP.Transformation;


namespace ApplicationDSP.Controllers
{
    public abstract class Mediator
    {
        public abstract void UpdateNumber( int selected, Colleague colleague );


        public abstract void UpdateTransformation( Transformations transformations );
    }
}