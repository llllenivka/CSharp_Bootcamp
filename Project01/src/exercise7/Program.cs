class MyProgramm
{
    public static void Main()
    {
        int quantity = 0;
        while(!InputUser.ProductQuantity(out quantity)) {}

        Dictionary<string, double> productPrices;
        InputUser.ProductPairs(quantity, out productPrices);

        if(productPrices.Count <= 0) InputUser.Message("Quantity of products = 0", ConsoleColor.Red);
        else 
        {
            double result = ArithmeticMean.Calculate(productPrices);
            InputUser.Message(String.Format("{0:F3}", result), ConsoleColor.Green);
        }
    }
}


