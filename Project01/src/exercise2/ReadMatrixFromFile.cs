public class ReadMatrixFromFile {
    public static bool  IsCorrectFile(string ? filename) {
        bool code = true;
        if(!File.Exists(filename)) {
            OutputUser.ErrorFile();
            code = false;
        }
        
        return code;
    }

    public static string[] ReadString(string filename) {
        return File.ReadAllLines(filename);
    }

    public static List<List<double>> ReadMatrix(string filename) {
        var matrix = new List<List<double>>();
        string[] matrixString = ReadString(filename);

        foreach(var line in matrixString) {
            matrix.Add(PushMatrix(line));
        }
        return matrix;
    }

    private static List<double> PushMatrix(string line) {
        var lineOfMatrix = new List<double>();
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