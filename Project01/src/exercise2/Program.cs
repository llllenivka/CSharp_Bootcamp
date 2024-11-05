using System;

class Program
{
    static void Main(string[] args) {
        var equations = new LinearAlgebraicEquation();
        equations.Calculation();
    }
    
    public class LinearAlgebraicEquation {
        public string filename = "1.txt";  // public string filename { get; set; } ПОМЕНЯЯЯТЬ!!!!!!!!
        List<List<int>> matrix = new List<List<int>>();

        public void Calculation() {
            if(!ReadMatrixFromFile.IsCorrectFile(filename)) return;
            matrix = ReadMatrixFromFile.ReadMatrix(filename);
            if(!IsCorrectMatrix()) {
                OutputUser.ErrorCalculation();
                return;
            }
        }

        private bool IsCorrectMatrix() {
            bool code = true;
            int prev_i = 0;
            for(int i = 1; i < matrix.Count; i++) {
                if(matrix[prev_i].Count != matrix[i].Count) {
                    code = false;
                    break;
                }
            }
            return code;
        }
    }


    public class OutputUser {
        public static void ErrorFile() => Console.WriteLine("Input error. File isn't exist");
        public static void ErrorCalculation() => Console.WriteLine("The system of linear algebraic equations has no solutions");
        public static void ErrorNumber() => Console.WriteLine("Couldn't parse a number. Please, try again");
    }

    public class ReadMatrixFromFile {
        public static bool  IsCorrectFile(string ? filename) {
            bool code = true;
            // filename = Console.ReadLine(); ПОТОМ ДОБАВЬ!!!!!!!!!!!!
            if(!File.Exists(filename)) {
                OutputUser.ErrorFile();
                code = false;
            }
            
            return code;
        }

        public static string[] ReadString(string filename) {
            return File.ReadAllLines(filename);
        }

        public static List<List<int>> ReadMatrix(string filename) {
            List<List<int>> matrix = new List<List<int>>();
            string[] matrixString = ReadString(filename);

            foreach(var line in matrixString) {
                matrix.Add(PushMatrix(line));
            }
            return matrix;
        }

        private static List<int> PushMatrix(string line) {
            List<int> lineOfMatrix = new List<int>();
            string[] splitLine = line.Split(" ");

            foreach(var numberString in splitLine) {
                int number;
                if(!int.TryParse(numberString, out  number)) {
                    OutputUser.ErrorNumber();
                } else {
                    lineOfMatrix.Add(number);
                }
            }

            return lineOfMatrix;
        }
    }


}