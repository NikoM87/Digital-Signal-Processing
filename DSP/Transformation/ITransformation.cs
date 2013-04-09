namespace DSP.Transformation
{
    public interface ITransformation
    {
        Signal Execute( Signal signal );
    }
}