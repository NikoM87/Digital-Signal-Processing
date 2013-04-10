namespace ApplicationDSP.Controllers
{
    public abstract class Colleague
    {
        protected readonly Mediator Mediator;


        protected Colleague( Mediator mediator )
        {
            Mediator = mediator;
        }
    }
}