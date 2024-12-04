static class InputUser
{
    public static bool ProductQuantity(out int quantity)
    {
        quantity = 0;
        Message("Enter the quantity of products :", ConsoleColor.Yellow);
        string ? input = Console.ReadLine();

        if(string.IsNullOrEmpty(input))
        {
            Message("Incorrect input. Please, try again", ConsoleColor.Red);
            return false;
        }

        if(!int.TryParse(input, out quantity))
        {
            Message("Couldn't parse quantity. Please, try again", ConsoleColor.Red);
            return false;
        }

        if(quantity <= 0)
        {
            Message("Incorrect input. quantity <= 0. Please, try again", ConsoleColor.Red);
            return false;
        }

        return true;
    }

    public static int ProductPairs(int quantity, out Dictionary<string, double> productPrices)
    {
        productPrices = new Dictionary<string, double>();
        for(int iteraition = 0; iteraition < quantity; iteraition++)
        {
            Message("Enter new product and price pair", ConsoleColor.Yellow);
            string ? input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                Message("Incorrect input. Please, try again", ConsoleColor.Red);
                quantity--;
                continue;
            }

            string[] splitInput = input.Split(" ");
            string product = splitInput[0];
            double price = 0;

            if(!double.TryParse(splitInput[1], out price))
            {
                Message("Couldn't parse a price. Please, try again", ConsoleColor.Red);
                quantity--;
                continue;
            }
            
            if(price <= 0) 
            {
                Message("Incorrect input. price <= 0", ConsoleColor.Red);
                continue;
            }

            if(productPrices.ContainsKey(product))
            {
                Message("This product is already on the list. Please, try again", ConsoleColor.Red);
                quantity--;
                continue;
            }

            productPrices.Add(product, price);
        }
        return productPrices.Count;
    }

    public static void Message(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}