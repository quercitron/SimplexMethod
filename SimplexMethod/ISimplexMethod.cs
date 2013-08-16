namespace SimplexMethod
{
    public interface ISimplexMethod
    {
        double[] Simplex(double[,] initA, double[] initb, double[] c);
    }
}