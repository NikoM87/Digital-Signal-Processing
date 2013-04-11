using DSP.Transformation;


namespace ApplicationDSP.Controllers
{
    public class TransformationsColleague : Colleague
    {
        public TransformationsColleague( SignalMediator mediator )
            : base( mediator )
        {
        }


        public void Update( Transformations transformations )
        {
            Mediator.UpdateTransformation( transformations );
        }
    }
}