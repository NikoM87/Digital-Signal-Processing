namespace DSP
{
    public interface ITransformation
    {
        Signal Execute( Signal signal );
    }
}