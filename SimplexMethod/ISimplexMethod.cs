namespace SimplexMethod
{
    public interface ISimplexMethod
    {
        SimplexMethodResult Simplex(double[,] initA, double[] initb, double[] c);
    }
}