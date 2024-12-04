static class InputUser
{
    public static bool InputParents(out List<int> ? parents) 
    {
        parents = new List<int>();

        WriteLineColor("Enter the parent array :", ConsoleColor.Yellow);
        string ? input = Console.ReadLine();

        if(string.IsNullOrEmpty(input))
        {
            WriteLineColor("Input is empty or null. Please, try again.", ConsoleColor.Red);
            return false;
        }

        var splitInput= input.Split(",")
            .Select(p => p.Trim())
            .Where(p => !string.IsNullOrEmpty(p));
        
        foreach(var parent in splitInput) 
        {
            int value;
            if(!int.TryParse(parent, out value)) 
            {
                WriteLineColor("Couldn't parse array of numbers. Please, try again", ConsoleColor.Red);
                return false;
            }
            if(value >= parents.Count || value < -1)
            {
                WriteLineColor("Invalid number array. Please, try again", ConsoleColor.Red);
                return false;
            }
            parents.Add(value);
            
        }

        return true;
    }
    public static bool InputString(int countParents, out string ? input)
    {
        WriteLineColor("ENTER THE VALUE OF THE NODES :", ConsoleColor.Yellow);
        input = Console.ReadLine();

        if(string.IsNullOrEmpty(input))
        {
            WriteLineColor("Input is empty or null. Please, try again.", ConsoleColor.Red);
            return false;
        }

        if(input.Length != countParents)
        {
            WriteLineColor("Incorrect string length . Please, try again.", ConsoleColor.Red);
            return false;
        }

        if(!input.All(c => c >= 'a' && c <= 'z')) 
        {
            WriteLineColor("Couldn't parse a words. Please, try again", ConsoleColor.Red);
            return false;
        }

        return true;
    }

    public static void WriteLineColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor(); 
    }
}