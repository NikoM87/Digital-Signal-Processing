namespace ApplicationDSP.Controllers
{
    public abstract class Colleague
    {
        protected readonly SignalMediator Mediator;


        protected Colleague( SignalMediator mediator )
        {
            Mediator = mediator;
        }
    }
}