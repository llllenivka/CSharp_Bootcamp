using System;

class Program
{
    static void Main(string[] args) {
        var equations = new LinearAlgebraicEquation();
        equations.Calculation();
    }
    
    public class LinearAlgebraicEquation {
        private string ? filename = "1.txt";
        List<List<int>> matrix;

        public void Calculation() {
            // filename = Console.ReadLine(); ПОТОМ ДОБАВЬ!!!!!!!!!!!!
            if(!File.Exists(filename) || string.IsNullOrEmpty(filename)) {
                OutputUser.ErrorFile();
            }
        }
    }


    public class OutputUser {
        public static void ErrorFile() => Console.WriteLine("Input error. File isn't exist");
        public static void ErrorCalculation() => Console.WriteLine("The system of linear algebraic equations has no solutions");
        public static void ErrorNumber() => Console.WriteLine("Couldn't parse a number. Please, try again");
    }


}
