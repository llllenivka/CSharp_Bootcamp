class ArithmeticMean
{
    public static double Calculate(Dictionary<string, double> productPrices)
    {
        double result  = 0;

        foreach(var item in productPrices)
        {
            result += item.Value;
        }

        return result / productPrices.Count;
    }
}