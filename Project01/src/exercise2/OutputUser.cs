public class OutputUser {
    public static void ErrorFile() => Console.WriteLine("Input error. File isn't exist");
    public static void ErrorCalculation() => Console.WriteLine("The system of linear algebraic equations has no solutions");
    public static void ErrorNumber() => Console.WriteLine("Couldn't parse a number. Please, try again");
    public static void ResultEquation(List<double> result) {
        for(int i = 0; i < result.Count; i++) {
            Console.WriteLine($"x{i + 1} = {result[i]}");
        }
    }
}